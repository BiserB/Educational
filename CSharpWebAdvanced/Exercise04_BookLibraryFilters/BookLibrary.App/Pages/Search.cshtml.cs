using BookLibrary.App.Auxiliary;
using BookLibrary.App.Models;
using BookLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.App.Pages
{
    public class SearchModel : PageModelWithDb
    {
        public SearchModel(BookLibraryDbContext db) : base(db)
        {
            this.Results = new List<SearchResult>();
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List<SearchResult> Results { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(this.SearchTerm))
            {
                return;
            }

            var searchTermLower = this.SearchTerm.ToLower();

            var bookResults = db.Books
                                .Where(b => b.Title.ToLower().Contains(searchTermLower))
                                .Select(b => new SearchResult
                                {
                                    Id = b.Id,
                                    Name = b.Title,
                                    Type = "book"
                                })
                                .ToList();

            var authorResults = db.Authors
                                  .Where(a => a.Name.ToLower().Contains(searchTermLower))
                                  .Select(a => new SearchResult
                                  {
                                      Id = a.Id,
                                      Name = a.Name,
                                      Type = "author"
                                  })
                                  .ToList();

            var results = new List<SearchResult>();

            results.AddRange(bookResults);
            results.AddRange(authorResults);

            var orderedResults = results.OrderBy(r => r.Name).ToList();

            string prefix = "<strong class=\"text-danger\">";
            string sufix = "</strong>";

            for (int i = 0; i < orderedResults.Count; i++)
            {
                orderedResults[i].Name = orderedResults[i].Name.EscapeIgnoreCase(SearchTerm, prefix, sufix);
            }

            this.Results = orderedResults;
        }
    }
}
using BookLibrary.App.Auxiliary;
using BookLibrary.App.Models;
using BookLibrary.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.App.Pages
{
    public class SearchModel : PageModel
    {
        private readonly BookLibraryDbContext db;

        public SearchModel(BookLibraryDbContext db)
        {
            this.db = db;
            this.Results = new List<SearchResult>();
        }

        public string SearchTerm { get; set; }

        public List<SearchResult> Results { get; set; }

        public void OnGet(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return;
            }

            this.SearchTerm = searchTerm;

            var searchTermLower = searchTerm.ToLower();

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
                orderedResults[i].Name = orderedResults[i].Name.EscapeIgnoreCase(searchTerm, prefix, sufix);
            }

            this.Results = orderedResults;
        }
    }
}
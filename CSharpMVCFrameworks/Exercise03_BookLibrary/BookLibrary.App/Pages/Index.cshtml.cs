using BookLibrary.App.Models;
using BookLibrary.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookLibraryDbContext db;

        public IndexModel(BookLibraryDbContext db)
        {
            this.db = db;
        }

        public List<BookInfo> Books { get; set; }

        public void OnGet()
        {
            this.Books = db.Books
                          .Select(b => new BookInfo
                          {
                              Id = b.Id,
                              Title = b.Title,
                              AuthorId = b.AuthorId,
                              Author = b.Author.Name,
                              Status = b.Status.Name
                          })
            .ToList();
        }
    }
}
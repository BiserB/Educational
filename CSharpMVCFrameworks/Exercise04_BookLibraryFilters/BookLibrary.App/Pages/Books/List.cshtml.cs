using BookLibrary.App.Models;
using BookLibrary.Data;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.App.Pages.Books
{
    public class ListModel : PageModelWithDb
    {
        public ListModel(BookLibraryDbContext db) : base(db)
        {
        }

        public List<BookInfo> Books { get; set; }

        public void OnGet()
        {
            using (this.db)
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
}
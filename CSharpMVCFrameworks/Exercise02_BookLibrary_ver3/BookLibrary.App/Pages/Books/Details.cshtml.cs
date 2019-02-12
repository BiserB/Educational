using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace BookLibrary.App.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly BookLibraryDbContext db;

        public DetailsModel(BookLibraryDbContext db)
        {
            this.db = db;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public string CoverImageUrl { get; set; }

        public string Description { get; set; }

        public int StatusId { get; set; }

        public string Status { get; set; }

        public IActionResult OnGet(int id)
        {
            Book book = db.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                ViewData["Message"] = "No such book!";

                return Page();
            }

            string authorName = db.Authors.Find(book.AuthorId).Name;
            string categoryName = db.Categories.Find(book.CategoryId).Name;
            string status = db.Status.Find(book.StatusId).Name;

            this.Id = book.Id;
            this.Title = book.Title;
            this.AuthorName = authorName;
            this.CategoryName = categoryName;
            this.CoverImageUrl = book.CoverImageUrl;
            this.Description = book.Description;
            this.StatusId = book.StatusId;
            this.Status = status;

            return Page();
        }
    }
}
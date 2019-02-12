using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookLibrary.App.Pages.Books
{
    public class AddModel : PageModel
    {
        private readonly BookLibraryDbContext db;

        public AddModel(BookLibraryDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string AuthorName { get; set; }

        [BindProperty]
        public string CategoryName { get; set; }

        [BindProperty]
        [Display(Name = "Image Url")]
        [Url]
        public string CoverImageUrl { get; set; }

        [BindProperty]
        public string Description { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            Book book = this.AddBook();
            return this.RedirectToPage("/Books/Details", new { id = book.Id });
        }

        private Book AddBook()
        {
            var author = db.Authors.FirstOrDefault(a => a.Name == this.AuthorName);

            if (author == null)
            {
                author = new Author { Name = this.AuthorName };
                db.Authors.Add(author);
                db.SaveChanges();
            }

            var category = db.Categories.FirstOrDefault(c => c.Name == this.CategoryName);

            if (category == null)
            {
                category = new Category { Name = this.CategoryName };
                db.Categories.Add(category);
                db.SaveChanges();
            }

            var book = new Book
            {
                Title = this.Title,
                AuthorId = author.Id,
                CategoryId = category.Id,
                CoverImageUrl = this.CoverImageUrl,
                Description = this.Description
            };

            db.Books.Add(book);
            db.SaveChanges();
            return book;
        }
    }
}
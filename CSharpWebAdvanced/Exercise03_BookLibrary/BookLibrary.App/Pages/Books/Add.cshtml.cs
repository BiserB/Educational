using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookLibrary.App.Pages.Books
{
    public class AddModel : PageModelWithDb
    {
        public AddModel(BookLibraryDbContext db) : base(db) { }

        [BindProperty]
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        [BindProperty]
        [Required]
        [MaxLength(128)]
        public string AuthorName { get; set; }

        [BindProperty]
        [Required]
        [MaxLength(128)]
        public string CategoryName { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Image Url")]
        [Url]
        [MaxLength(256)]
        public string CoverImageUrl { get; set; }

        [BindProperty]
        [Required]
        [MaxLength(1024)]
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
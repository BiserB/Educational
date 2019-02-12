using BookLibrary.BindingModels;
using BookLibrary.Data;
using BookLibrary.Models;
using BookLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookLibrary.Controllers
{
    public class BooksController : Controller
    {
        public BooksController(BookLibraryDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public BookLibraryDbContext DbContext { get; set; }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddBookBindingModel bookModel)
        {
            if (ModelState.IsValid)
            {
                var author = DbContext.Authors.FirstOrDefault(a => a.Name == bookModel.AuthorName);

                if (author == null)
                {
                    author = new Author() { Name = bookModel.AuthorName };
                    DbContext.Authors.Add(author);
                    DbContext.SaveChanges();
                }

                var category = DbContext.Categories.FirstOrDefault(c => c.Name == bookModel.CategoryName);

                if (category == null)
                {
                    category = new Category() { Name = bookModel.CategoryName };
                    DbContext.Categories.Add(category);
                    DbContext.SaveChanges();
                }

                Book book = new Book()
                {
                    Title = bookModel.Title,
                    AuthorId = author.Id,
                    CategoryId = category.Id,
                    Description = bookModel.Description,
                    CoverImageUrl = bookModel.CoverImageUrl
                };

                DbContext.Books.Add(book);
                DbContext.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {   
            if (!DbContext.Books.Any(b => b.Id == id))
            {
                ViewData["Message"] = "Error! There is no such book!";

                return View();
            }

            var book = DbContext.Books.Find(id);

            string authorName = DbContext.Authors.First(a => a.Id == book.AuthorId).Name;

            string categoryName = DbContext.Categories.First(c => c.Id == book.CategoryId).Name;

            bool available = book.Loans.TrueForAll(l => l.IsReturned == true);

            string status = (available) ? "At home" : "Borrowed";

            var bookModel = new BookDetailsViewModel()
            {
                Title = book.Title,
                Author = authorName,
                Category = categoryName,
                Description = book.Description,
                CoverImageUrl = book.CoverImageUrl,
                Status = status
            };

            return View(bookModel);
        }
    }
}
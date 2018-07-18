using BookLibrary.Data;
using BookLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    public class AuthorsController: Controller
    {
        public AuthorsController(BookLibraryDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public BookLibraryDbContext DbContext { get; set; }

        public IActionResult Details(int id)
        {
            var author = DbContext.Authors.FirstOrDefault(a => a.Id == id);

            if (author == null)
            {
                ViewData["Message"] = "Error! There is no such author!";

                return View();
            }

            var booksInfo = new List<(int, string, string)>();

            var authorBooks = DbContext.Books.Where(b => b.AuthorId == author.Id).ToList();

            foreach (var book in authorBooks)
            {
                bool isAvailable = book.Loans.TrueForAll(l => l.IsReturned == true);

                string status = isAvailable ? "At home" : "Borrowed";

                booksInfo.Add((book.Id, book.Title, status));
            }

            var authorModel = new AuthorDetailsViewModel()
            {
                Name = author.Name,
                Books = booksInfo
            };           

            return View(authorModel);
        }

    }
}

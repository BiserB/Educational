using BookLibrary.Data;
using BookLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BookLibrary.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(BookLibraryDbContext db)
        {
            using (db)
            {
                var books = db.Books.Select(b => new { b.Id, b.Title, b.AuthorId, AuthorName = b.Author.Name, b.Loans }).ToList();
                var bookViews = new List<BookViewModel>(books.Count);

                foreach (var book in books)
                {
                    var loans = book.Loans;
                    string status = "At home";

                    if (loans.Any(l => l.IsReturned == false))
                    {
                        status = "Borrowed";
                    }

                    var model = new BookViewModel()
                    {
                        Id = book.Id,
                        Title = book.Title,
                        AuthorId = book.AuthorId,
                        Author = book.AuthorName,
                        Status = status
                    };

                    bookViews.Add(model);
                }

                return View(bookViews);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
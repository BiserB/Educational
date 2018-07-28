using BookLibrary.App.Auxiliary;
using BookLibrary.App.Filters;
using BookLibrary.App.Models;
using BookLibrary.App.Models.BindingModels;
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookLibrary.App.Controllers
{
    [Authorize]
    public class MovieLoansController : BaseController
    {
        public MovieLoansController(BookLibraryDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Add()
        {
            var borrowers = db.Borrowers
                               .Select(b => new MinInfo()
                               {
                                   Id = b.Id,
                                   Name = b.Name
                               })
                               .ToList();

            var movies = db.Movies
                            .Where(m => m.StatusId == 1)
                            .Select(m => new MinInfo()
                            {
                                Id = m.Id,
                                Name = m.Title
                            })
                            .ToList();

            var model = new AddLoanBindingModel()
            {
                Borrowers = borrowers,
                Items = movies
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddLoanBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var movieLoan = new MovieLoan()
            {
                BorrowerId = model.BorrowerId,
                MovieId = model.ItemId,
                DateOfLoan = model.DateOfLoan,
                DueDate = model.DueDate
            };

            db.MovieLoans.Add(movieLoan);
            db.Movies.Find(model.ItemId).StatusId = ItemStatus.Borrowed;
            db.SaveChanges();

            return RedirectToPage("/Loans/List");
        }
    }
}
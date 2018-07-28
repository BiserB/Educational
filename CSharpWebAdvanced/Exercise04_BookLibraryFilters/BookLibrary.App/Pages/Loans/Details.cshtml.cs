using BookLibrary.App.Auxiliary;
using BookLibrary.App.Models;
using BookLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookLibrary.App.Pages.Loans
{
    public class DetailsModel : PageModelWithDb
    {
        public DetailsModel(BookLibraryDbContext db) : base(db)
        {
        }

        public LoanInfo Loan { get; set; }

        public IActionResult OnGet(int id, string type)
        {
            if (type == "Book")
            {
                var bookLoan = db.BookLoans
                             .Include(l => l.Book)
                             .Include(l => l.Borrower)
                             .FirstOrDefault(l => l.Id == id);

                if (bookLoan == null)
                {
                    return this.RedirectToPage("/Messages", new { id = 3 });
                }

                this.Loan = new LoanInfo()
                {
                    Id = bookLoan.Id,
                    Type = "Book",
                    ItemId = bookLoan.BookId,
                    ItemTitle = bookLoan.Book.Title,
                    BorrowerId = bookLoan.BorrowerId,
                    BorrowerName = bookLoan.Borrower.Name,
                    DateOfLoan = bookLoan.DateOfLoan.ToShortDateString(),
                    DueDate = bookLoan.DueDate.ToShortDateString(),
                    Status = bookLoan.IsOverdue() == false ? "OK" : "Overdue",
                    IsReturned = bookLoan.IsReturned
                };
            }
            else if (type == "Movie")
            {
                var movieLoan = db.MovieLoans
                            .Include(l => l.Movie)
                            .Include(l => l.Borrower)
                            .FirstOrDefault(l => l.Id == id);

                if (movieLoan == null)
                {
                    return this.RedirectToPage("/Messages", new { id = 3 });
                }

                this.Loan = new LoanInfo()
                {
                    Id = movieLoan.Id,
                    Type = "Movie",
                    ItemId = movieLoan.MovieId,
                    ItemTitle = movieLoan.Movie.Title,
                    BorrowerId = movieLoan.BorrowerId,
                    BorrowerName = movieLoan.Borrower.Name,
                    DateOfLoan = movieLoan.DateOfLoan.ToShortDateString(),
                    DueDate = movieLoan.DueDate.ToShortDateString(),
                    Status = movieLoan.IsOverdue() == false ? "OK" : "Overdue",
                    IsReturned = movieLoan.IsReturned
                };
            }
            else
            {
                return this.RedirectToPage("/Messages", new { id = 3 });
            }

            return this.Page();
        }

        public IActionResult OnPost(int id, string type)
        {
            if (type == "Book")
            {
                var loan = db.BookLoans.FirstOrDefault(b => b.Id == id);

                if (loan == null)
                {
                    return this.RedirectToPage("/Message", new { id = 3 });
                }

                loan.IsReturned = true;

                loan.ReturnDate = DateTime.Now;

                var book = db.Books.FirstOrDefault(b => b.Id == loan.BookId);

                book.StatusId = ItemStatus.AtHome;

                db.SaveChanges();
            }
            else if (type == "Movie")
            {
                var loan = db.MovieLoans.FirstOrDefault(m => m.Id == id);

                if (loan == null)
                {
                    return this.RedirectToPage("/Message", new { id = 3 });
                }

                loan.IsReturned = true;

                loan.ReturnDate = DateTime.Now;

                var movie = db.Movies.FirstOrDefault(m => m.Id == loan.MovieId);

                movie.StatusId = ItemStatus.AtHome;

                db.SaveChanges();
            }

            return this.RedirectToPage("/Message", new { msgId = 1 });
        }
    }
}
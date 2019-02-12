using BookLibrary.App.Models;
using BookLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.App.Pages.Borrowers
{
    public class DetailsModel : PageModelWithDb
    {
        public DetailsModel(BookLibraryDbContext db) : base(db)
        {
        }

        public List<LoanMinInfo> Loans { get; set; } = new List<LoanMinInfo>();

        public BorrowerInfo Borrower { get; set; }

        public int CountOfOverdue { get; set; }

        public IActionResult OnGet(int id)
        {
            var borrower = db.Borrowers.Include(b => b.Loans).FirstOrDefault(b => b.Id == id);

            if (borrower == null)
            {
                return this.RedirectToPage("/Message", new { msgId = 2 });
            }

            var bookLoans = db.BookLoans
                           .Where(l => l.BorrowerId == id)
                           .OrderBy(l => l.DateOfLoan)
                           .Select(l => new LoanMinInfo()
                           {
                               Id = l.Id,
                               Type = "Book",
                               ItemId = l.BookId,
                               ItemTitle = l.Book.Title,
                               DateOfLoan = l.DateOfLoan.ToShortDateString(),
                               DueDate = l.DueDate.ToShortDateString(),
                               IsReturned = l.IsReturned,
                               IsOverdue = l.IsOverdue()
                           })
                           .ToList();

            var movieLoans = db.MovieLoans
                           .Where(l => l.BorrowerId == id)
                           .OrderBy(l => l.DateOfLoan)
                           .Select(l => new LoanMinInfo()
                           {
                               Id = l.Id,
                               Type = "Movie",
                               ItemId = l.MovieId,
                               ItemTitle = l.Movie.Title,
                               DateOfLoan = l.DateOfLoan.ToShortDateString(),
                               DueDate = l.DueDate.ToShortDateString(),
                               IsReturned = l.IsReturned,
                               IsOverdue = l.IsOverdue()
                           })
                           .ToList();

            this.Loans.AddRange(bookLoans);
            this.Loans.AddRange(movieLoans);

            this.Borrower = BorrowerInfo.FromBorrower(borrower);

            this.CountOfOverdue = this.Loans
                                      .Where(l => l.IsOverdue == true)
                                      .Count();

            return this.Page();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.App.Auxiliary;
using BookLibrary.App.Models;
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.App.Pages.Loans
{
    public class DetailsModel : PageModelWithDb
    {
        public DetailsModel(BookLibraryDbContext db) : base(db) { }

        public LoanInfo Loan { get; set; }

        public IActionResult OnGet(int id)
        {
            using (this.db)
            {
                var loan = db.Loans
                             .Include(l => l.Book)
                             .Include(l => l.Borrower)
                             .FirstOrDefault(l => l.Id == id);

                if (loan == null)
                {
                    return this.RedirectToPage("/Messages", new { id = 3});
                }

                this.Loan = new LoanInfo()
                {
                    Id = loan.Id,
                    BookId = loan.BookId,
                    BookTitle = loan.Book.Title,
                    BorrowerId = loan.BorrowerId,
                    BorrowerName = loan.Borrower.Name,
                    DateOfLoan = loan.DateOfLoan.ToShortDateString(),
                    DueDate = loan.DueDate.ToShortDateString(),
                    Status = loan.IsOverdue() == false ? "OK" : "Overdue",
                    IsReturned = loan.IsReturned
                };

                return this.Page();
            }
        }

        public IActionResult OnPost(int id)
        {
            var loan = db.Loans.FirstOrDefault(b => b.Id == id);

            if (loan == null)
            {
                return this.RedirectToPage("/Message", new { id = 3 });
            }

            loan.IsReturned = true;

            loan.ReturnDate = DateTime.Now;

            var book = db.Books.FirstOrDefault(b => b.Id == loan.BookId);

            book.StatusId = BookStatus.AtHome;

            db.SaveChanges();

            return this.RedirectToPage("/Message", new { msgId = 1 });
        }

    }
}
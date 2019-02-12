using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary.App.Models;
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.App.Pages.Borrowers
{
    public class DetailsModel : PageModelWithDb
    {
        public DetailsModel(BookLibraryDbContext db) : base(db) { }

        public List<LoanMinInfo> Loans { get; set; }

        public BorrowerInfo Borrower { get; set; }

        public int CountOfOverdue { get; set; }

        public IActionResult OnGet(int id)
        {
            var borrower = db.Borrowers.Include(b => b.Loans).FirstOrDefault(b => b.Id == id);

            if (borrower == null)
            {
                return this.RedirectToPage("/Message", new { msgId = 2});
            }

            this.Loans = db.Loans                           
                           .Where(l => l.BorrowerId == id)
                           .OrderBy(l => l.DateOfLoan)
                           .Select(l => new LoanMinInfo()
                           {
                               Id = l.Id,
                               BookId = l.BookId,
                               BookTitle = l.Book.Title,
                               DateOfLoan = l.DateOfLoan.ToShortDateString(),
                               DueDate = l.DueDate.ToShortDateString(),
                               IsReturned = l.IsReturned
                           })
                           .ToList();

            this.Borrower = BorrowerInfo.FromBorrower(borrower);

            this.CountOfOverdue = db.Loans
                                    .Where(l => l.BorrowerId == id && l.IsOverdue() == true)
                                    .Count();


            return this.Page();
        }
    }
}
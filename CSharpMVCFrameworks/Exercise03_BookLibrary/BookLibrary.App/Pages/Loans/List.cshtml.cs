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
    public class ListModel : PageModelWithDb
    {
        public ListModel(BookLibraryDbContext db) : base(db) { }

        public List<LoanInfo> LoanList { get; set; }

        public string Option { get; set; }

        public void OnGet(string option)
        {
            bool token1 = true, token2 = false;

            this.Option = option;

            switch (option)
            {
                case "returned":
                    token1 = true;
                    token2 = true;
                    break;
                case "active":
                    token1 = false;
                    token2 = false;
                    break;
                case "all":
                    token1 = true;
                    token2 = false;
                    break;
            }

            this.LoanList = this.db.Loans
                                .Include(l => l.Book)
                                .Where(l => l.IsReturned == token1 || l.IsReturned == token2)
                                .OrderBy(l => l.DateOfLoan)
                                .Select(l => new LoanInfo()
                                {
                                    Id = l.Id,
                                    BookId = l.BookId,
                                    BookTitle = l.Book.Title,
                                    BorrowerId = l.BorrowerId,
                                    BorrowerName = l.Borrower.Name,
                                    DateOfLoan = l.DateOfLoan.ToShortDateString(),
                                    DueDate = l.DueDate.ToShortDateString(),
                                    Status = l.IsOverdue() == false ? "OK" : "Overdue",
                                    IsReturned = l.IsReturned
                                })                                  
                                .ToList();
        }  
    }
}
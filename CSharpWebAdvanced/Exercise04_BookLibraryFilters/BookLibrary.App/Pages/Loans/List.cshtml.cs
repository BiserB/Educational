using BookLibrary.App.Models;
using BookLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.App.Pages.Loans
{
    public class ListModel : PageModelWithDb
    {
        public ListModel(BookLibraryDbContext db) : base(db)
        {
        }

        public List<LoanInfo> LoanList { get; set; } = new List<LoanInfo>();

        public string Option { get; set; }

        public void OnGet(string option)
        {
            bool token1 = true, token2 = false;

            if (option != null)
            {
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
            }

            var BookLoans = this.db.BookLoans
                                .Include(l => l.Book)
                                .Where(l => l.IsReturned == token1 || l.IsReturned == token2)
                                .OrderBy(l => l.DateOfLoan)
                                .Select(l => new LoanInfo()
                                {
                                    Id = l.Id,
                                    Type = "Book",
                                    ItemId = l.BookId,
                                    ItemTitle = l.Book.Title,
                                    BorrowerId = l.BorrowerId,
                                    BorrowerName = l.Borrower.Name,
                                    DateOfLoan = l.DateOfLoan.ToShortDateString(),
                                    DueDate = l.DueDate.ToShortDateString(),
                                    Status = l.IsOverdue() == false ? "OK" : "Overdue",
                                    IsReturned = l.IsReturned
                                })
                                .ToList();

            var MovieLoans = this.db.MovieLoans
                                .Include(l => l.Movie)
                                .Where(l => l.IsReturned == token1 || l.IsReturned == token2)
                                .OrderBy(l => l.DateOfLoan)
                                .Select(l => new LoanInfo()
                                {
                                    Id = l.Id,
                                    Type = "Movie",
                                    ItemId = l.MovieId,
                                    ItemTitle = l.Movie.Title,
                                    BorrowerId = l.BorrowerId,
                                    BorrowerName = l.Borrower.Name,
                                    DateOfLoan = l.DateOfLoan.ToShortDateString(),
                                    DueDate = l.DueDate.ToShortDateString(),
                                    Status = l.IsOverdue() == false ? "OK" : "Overdue",
                                    IsReturned = l.IsReturned
                                })
                                .ToList();

            this.LoanList.AddRange(BookLoans);
            this.LoanList.AddRange(MovieLoans);
        }
    }
}
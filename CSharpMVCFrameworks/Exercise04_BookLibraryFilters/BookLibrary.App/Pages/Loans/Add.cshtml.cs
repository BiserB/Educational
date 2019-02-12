using BookLibrary.App.Auxiliary;
using BookLibrary.App.Filters;
using BookLibrary.App.Models;
using BookLibrary.App.Models.BindingModels;
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookLibrary.App.Pages.Loans
{
    [Authorize]
    public class AddModel : PageModelWithDb
    {
        public AddModel(BookLibraryDbContext db) : base(db)
        {
            this.Loan = new AddLoanBindingModel();
        }

        [BindProperty]
        public int BorrowerId { get; set; }

        [BindProperty]
        public int ItemId { get; set; }

        [BindProperty]
        public AddLoanBindingModel Loan { get; set; }

        public void OnGet()
        {
            this.Loan.Borrowers = db.Borrowers
                               .Select(b => new MinInfo()
                               {
                                   Id = b.Id,
                                   Name = b.Name
                               })
                               .ToList();

            this.Loan.Items = db.Books
                           .Where(b => b.StatusId == ItemStatus.AtHome)
                           .Select(b => new MinInfo()
                           {
                               Id = b.Id,
                               Name = b.Title
                           })
                           .ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            BookLoan loan = new BookLoan()
            {
                BookId = this.ItemId,
                BorrowerId = this.BorrowerId,
                DateOfLoan = this.Loan.DateOfLoan,
                DueDate = this.Loan.DueDate
            };

            db.BookLoans.Add(loan);
            db.Books.Find(this.ItemId).StatusId = ItemStatus.Borrowed;
            db.SaveChanges();

            return RedirectToPage("/Loans/List");
        }

        public void OnGetFromBook(int id)
        {
            this.Loan.Borrowers = db.Borrowers
                               .Select(b => new MinInfo()
                               {
                                   Id = b.Id,
                                   Name = b.Name
                               })
                               .ToList();

            this.Loan.Items = db.Books
                           .Where(b => b.Id == id)
                           .Select(b => new MinInfo()
                           {
                               Id = b.Id,
                               Name = b.Title
                           })
                           .ToList();
        }
    }
}
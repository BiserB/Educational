
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BookLibrary.App.Pages.Loans
{
    public class AddModel : PageModelWithDb
    {
        public AddModel(BookLibraryDbContext db) : base(db) { }

        [BindProperty]
        [Required]
        public string BookId { get; set; }

        [BindProperty]
        [Required]
        public string BorrowerId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You have to specify a date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/2001", "1/1/2020")]
        public DateTime DateOfLoan { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "You have to specify a date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]        
        [Range(typeof(DateTime), "1/1/2001", "1/1/2020")]        
        public DateTime DueDate { get; set; }

        public List<SelectListItem> Borrowers = new List<SelectListItem>();

        public List<SelectListItem> Books = new List<SelectListItem>();

        public void OnGet()
        {
            this.Borrowers = db.Borrowers
                               .Select(b => new SelectListItem()
                               {
                                   Value = b.Id.ToString(),
                                   Text = b.Name
                               })
                               .ToList();
            this.Books = db.Books
                           .Where(b => b.StatusId == 1)
                           .Select(b => new SelectListItem()
                           {
                               Value = b.Id.ToString(),
                               Text = b.Title
                           })
                           .ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            if (this.DateOfLoan > this.DueDate)
            {
                this.ViewData["Message"] = "Due date must be after date of loan!";
                return this.Page();
            }

            int bookId = int.Parse(this.BookId);

            Loan loan = new Loan()
            {
                BookId = bookId,
                BorrowerId = int.Parse(this.BorrowerId),
                DateOfLoan = this.DateOfLoan,
                DueDate = this.DueDate
            };

            db.Loans.Add(loan);
            db.Books.Find(bookId).StatusId = 2;
            db.SaveChanges();

            return RedirectToPage("/Index");
        }

        public void OnGetFromBook(int id)
        {
            this.Borrowers = db.Borrowers
                               .Select(b => new SelectListItem()
                               {
                                   Value = b.Id.ToString(),
                                   Text = b.Name
                               })
                               .ToList();
            this.Books = db.Books
                           .Where(b => b.Id == id)
                           .Select(b => new SelectListItem()
                           {
                               Value = b.Id.ToString(),
                               Text = b.Title
                           })
                           .ToList();
        }
    }
}
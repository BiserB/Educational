using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.App.Pages.Borrowers
{
    public class AddModel : PageModel
    {
        private readonly BookLibraryDbContext db;

        public AddModel(BookLibraryDbContext db)
        {
            this.db = db;
        }

        [Required]
        [BindProperty]
        public string Name { get; set; }

        [Required]
        [BindProperty]
        public string Address { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            var borrower = new Borrower()
            {
                Name = this.Name,
                Address = this.Address
            };

            this.db.Borrowers.Add(borrower);
            this.db.SaveChanges();

            return this.RedirectToPage("/Index");
        }
    }
}
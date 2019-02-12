using BookLibrary.App.Models;
using BookLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.App.Pages.Borrowers
{
    public class ListModel : PageModelWithDb
    {
        public ListModel(BookLibraryDbContext db) : base(db)
        {
        }

        public List<BorrowerInfo> Borrowers { get; set; }

        public void OnGet()
        {
            this.Borrowers = db.Borrowers
                               .Include(b => b.Loans)
                               .Include(b => b.MovieLoans)
                               .Select(BorrowerInfo.FromBorrower)
                               .ToList();
        }
    }
}
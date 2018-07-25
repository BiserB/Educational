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
    public class ListModel : PageModelWithDb
    {
        public ListModel(BookLibraryDbContext db) : base(db) { }

        public List<BorrowerInfo> Borrowers { get; set; }

        public void OnGet()
        {
            this.Borrowers = db.Borrowers
                               .Include(b => b.Loans)
                               .Select(BorrowerInfo.FromBorrower)
                               .ToList();
        }
    }
}
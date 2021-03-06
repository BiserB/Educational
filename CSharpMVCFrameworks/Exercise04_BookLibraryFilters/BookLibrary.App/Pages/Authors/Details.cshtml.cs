﻿using BookLibrary.App.Models;
using BookLibrary.Data;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.App.Pages.Authors
{
    public class DetailsModel : PageModelWithDb
    {
        public DetailsModel(BookLibraryDbContext db) : base(db)
        {
        }

        public string AuthorName { get; set; }

        public List<BookMinInfo> Books { get; set; }

        public void OnGet(int id)
        {
            this.Books = db.Books
                           .Where(b => b.AuthorId == id)
                           .Select(b => new BookMinInfo
                           {
                               Id = b.Id,
                               Title = b.Title,
                               Status = b.Status.Name
                           })
                           .ToList();
        }
    }
}
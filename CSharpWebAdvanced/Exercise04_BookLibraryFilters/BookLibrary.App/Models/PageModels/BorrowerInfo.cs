using BookLibrary.Models;
using System;

namespace BookLibrary.App.Models
{
    public class BorrowerInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int CountOfLoans { get; set; }

        public static Func<Borrower, BorrowerInfo> FromBorrower
        {
            get
            {
                return b => new BorrowerInfo
                {
                    Id = b.Id,
                    Name = b.Name,
                    Address = b.Address,
                    CountOfLoans = b.Loans.Count + b.MovieLoans.Count
                };
            }
        }
    }
}
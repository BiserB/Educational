using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class BookLoan
    {
        public int Id { get; set; }

        public int BorrowerId { get; set; }

        [Required]
        public Borrower Borrower { get; set; }

        public int BookId { get; set; }

        [Required]
        public Book Book { get; set; }

        public DateTime DateOfLoan { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool IsReturned { get; set; }

        public bool IsOverdue()
        {
            if (this.ReturnDate != null && this.ReturnDate > this.DueDate)
            {
                return true;
            }

            if (this.ReturnDate == null && this.DueDate < DateTime.Now)
            {
                return true;
            }

            return false;
        }
    }
}
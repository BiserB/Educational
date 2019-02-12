using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public Author Author { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CoverImageUrl { get; set; }

        public List<Loan> Loans { get; set; } = new List<Loan>();
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Book
    {
        public Book()
        {
            this.StatusId = 1;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        [MaxLength(256)]
        public string CoverImageUrl { get; set; }

        public int StatusId { get; set; }

        [Required]
        public Status Status { get; set; }

        public List<BookLoan> Loans { get; set; } = new List<BookLoan>();
    }
}
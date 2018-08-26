using System;
using System.ComponentModel.DataAnnotations;

namespace Vote.Entities
{
    public class Reply
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        [Required]
        public Question Question { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public User Author { get; set; }

        [Required]
        [MaxLength(256)]
        public string Content { get; set; }

        public DateTime PublishedOn { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }
    }
}
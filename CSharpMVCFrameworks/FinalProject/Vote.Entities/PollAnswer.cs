using System;
using System.ComponentModel.DataAnnotations;

namespace Vote.Entities
{
    public class PollAnswer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Content { get; set; }

        public int Votes { get; set; }

        public int PollId { get; set; }

        [Required]
        public Poll Poll { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}
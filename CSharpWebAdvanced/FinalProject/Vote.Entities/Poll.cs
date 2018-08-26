using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vote.Entities
{
    public class Poll
    {
        public Poll()
        {
            this.MutipleAnswers = false;
            this.IsClosed = false;
            this.IsArchived = false;
            this.IsDeleted = false;
        }

        public int Id { get; set; }

        public int EventId { get; set; }

        [Required]
        public Event Event { get; set; }

        public int PollQuestionId { get; set; }

        [Required]
        public PollQuestion PollQuestion { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<PollAnswer> PollAnswers { get; set; }

        public bool MutipleAnswers { get; set; }

        public bool IsClosed { get; set; }

        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }
    }
}
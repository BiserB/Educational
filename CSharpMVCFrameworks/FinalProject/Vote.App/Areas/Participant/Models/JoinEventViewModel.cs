using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vote.App.Areas.Participant.Models
{
    public class JoinEventViewModel
    {
        public int EventId { get; set; }

        public string EventCode { get; set; }

        public string EventTitle { get; set; }

        public List<QuestionViewModel> Questions { get; set; }

        public bool IsAnonimous { get; set; }

        public string ParticipantId { get; set; }
        
        [Display(Name = "Your name")]
        [DefaultValue("Anonymous")]
        public string ParticipantName { get; set; }

        [Required]
        [MaxLength(256)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}

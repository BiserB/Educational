using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vote.Common.BindingModels
{
    public class CreateEventBindingModel 
    {
        public CreateEventBindingModel()
        {
            //this.StartDate = DateTime.Now.ToShortDateString();
            //this.EndDate = DateTime.Now.AddDays(7).ToShortDateString();
            //this.StartDate = DateTime.Now;
            //this.EndDate = DateTime.Now.Date;
        }

        [Required]
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Code { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required]
        public bool IsPrivate { get; set; }


        public bool AnonymousAllowed { get; set; }
    }
}

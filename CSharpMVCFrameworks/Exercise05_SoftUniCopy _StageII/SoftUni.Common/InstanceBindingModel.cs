using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftUni.Common
{
    public class InstanceBindingModel
    {
        public InstanceBindingModel()
        {
            this.AllTrainers = new List<SelectListItem>();
            this.StartDate = DateTime.Now.Date;
            //this.EndDate = DateTime.Now.Date;
        }

        [Required]
        [Display(Name = "Instance name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Instance start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Instance end date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public string TrainerId { get; set; }

        public int CourseId { get; set; }

        public int InstanceId { get; set; }

        public List<SelectListItem> AllTrainers { get; set; }
    }
}
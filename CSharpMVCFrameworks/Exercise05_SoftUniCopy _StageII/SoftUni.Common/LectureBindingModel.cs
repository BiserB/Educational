using System;
using System.ComponentModel.DataAnnotations;

namespace SoftUni.Common
{
    public class LectureBindingModel
    {
        public LectureBindingModel()
        {
            this.StartTime = DateTime.Now;
            this.EndTime = DateTime.Now;
        }

        [Required]
        [MinLength(3)]
        [MaxLength(120)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(120)]
        public string Description { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(120)]
        [Display(Name = "Lecture Hall")]
        public string LectureHall { get; set; }

        [Display(Name = "Start time")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Display(Name = "End time")]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        public int InstanceId { get; set; }

        public int LectureId { get; set; }
    }
}
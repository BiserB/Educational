using System.ComponentModel.DataAnnotations;

namespace SoftUni.Common
{
    public class AddCourseBindingModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }
    }
}
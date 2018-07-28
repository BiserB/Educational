using System.ComponentModel.DataAnnotations;

namespace BookLibrary.App.Models.BindingModels
{
    public class MovieBindingModel
    {
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Director Name")]
        public string DirectorName { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Cover Image")]
        [MaxLength(256)]
        [Url]
        public string CoverImageUrl { get; set; }
    }
}
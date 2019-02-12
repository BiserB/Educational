using System.ComponentModel.DataAnnotations;

namespace FDMC.Models.BindingModels
{
    public class AddCatBindingModel
    {
        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
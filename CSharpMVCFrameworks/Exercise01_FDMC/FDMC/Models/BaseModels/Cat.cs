using System.ComponentModel.DataAnnotations;

namespace FDMC.Models.BaseModels
{
    public class Cat
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
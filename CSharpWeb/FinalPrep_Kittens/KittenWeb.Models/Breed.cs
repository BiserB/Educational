
namespace KittenWeb.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Breed
    {
        public Breed()
        {
            this.Kittens = new List<Kitten>();
        }

        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [MaxLength(512)]
        public string ImageUrl { get; set; }

        public ICollection<Kitten> Kittens { get; set; }
    }
}


namespace KittenWeb.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Kitten
    {
        private DateTime birthdate;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int BreedId { get; set; }

        [Required]
        public Breed Breed { get; set; }

        public DateTime Birthdate { get; set; }
    }
}

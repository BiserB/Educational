
using System.ComponentModel.DataAnnotations;

namespace FDMC.Models
{
    public class Kitten
    {
        public Kitten(string name, double age, Breed breed)
        {
            this.Name = name;
            this.Age = age;
            this.Breed = breed;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 40)]
        public double Age { get; set; }

        public Breed Breed { get; set; }

        public int OwnerId { get; set; }

        [Required]
        public User Owner { get; set; }
    }
}

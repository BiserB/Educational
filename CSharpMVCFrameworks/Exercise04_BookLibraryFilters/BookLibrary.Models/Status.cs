using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
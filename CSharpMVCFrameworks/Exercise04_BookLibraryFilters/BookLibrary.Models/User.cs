using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Username { get; set; }

        [Required]
        [MinLength(64)]
        [MaxLength(64)]
        public string PasswordHash { get; set; }
    }
}
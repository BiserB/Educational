
namespace FDMC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User(string username, string password, string email)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.OwnedCats = new List<Kitten>();
        }

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Kitten> OwnedCats { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMvc.Domain
{
    public class User
    {
        public User()
        {
            this.Id = 0;
            this.Notes = new List<Note>();
        }

        public User(string username, string passwordHash)
        {
            this.Username = username;
            this.PasswordHash = passwordHash;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
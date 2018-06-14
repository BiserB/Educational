namespace HTTPServer.GameStoreApp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User(string fullName, string email, string passwordHash)
        {
            this.FullName = fullName;
            this.Email = email;
            this.PasswordHash = passwordHash;
            this.Games = new HashSet<UserGame>();
            this.IsAdmin = false;
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        [RegularExpression(@"\w+@\w+\.\w{2,10}")]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public ICollection<UserGame> Games { get; }
    }
}
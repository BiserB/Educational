using System.Collections.Generic;

namespace SoftUni.Common
{
    public class UserDetailsModel
    {
        public UserDetailsModel()
        {
            this.AllRoles = new List<string>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string PasswordHash { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public List<string> AllRoles { get; set; }
    }
}
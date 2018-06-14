using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HTTPServer.ByTheCakeApplication.Models
{
    public class User
    {
        public User()
        {
            this.Orders = new List<Order>();
        }

        public User(string name, string username, string password, DateTime date) : this()
        {
            this.Name = name;
            this.Username = username;
            this.PasswordHash = password;
            this.RegisteredOn = date;
            this.Orders = new List<Order>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime RegisteredOn { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
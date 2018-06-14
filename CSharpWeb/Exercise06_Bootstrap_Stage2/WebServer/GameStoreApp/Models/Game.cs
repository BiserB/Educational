namespace HTTPServer.GameStoreApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public Game()
        {
            this.Users = new HashSet<UserGame>();
        }

        public Game(string title, string trailerUrl, string imageUrl, double price, double size, string description, DateTime releaseDate)
            : this()
        {
            this.Title = title;
            this.TrailerUrl = trailerUrl;
            this.ImageUrl = imageUrl;
            this.Price = price;
            this.Size = size;
            this.Description = description;
            this.ReleaseDate = releaseDate;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        public string TrailerUrl { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(300)]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,4}\.\d{0,2}$")]
        [Range(0, 9999.99)]
        public double Price { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,4}\.\d{0,1}$")]
        [Range(0, 9999.99)]
        public double Size { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<UserGame> Users { get; set; }
    }
}
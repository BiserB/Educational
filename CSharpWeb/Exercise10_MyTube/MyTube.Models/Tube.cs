namespace MyTube.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tube
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        public string YouTubeId { get; set; }

        public int Views { get; set; }

        public int UploaderId { get; set; }

        [Required]
        public User Uploader { get; set; }
    }
}
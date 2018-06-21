using System.ComponentModel.DataAnnotations;

namespace SimpleMvc.Domain
{
    public class Note
    {
        public Note(string title, string content, int userId)
        {
            this.Title = title;
            this.Content = content;
            this.UserId = userId;
            this.IsDeleted = false;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public int UserId { get; set; }

        [Required]
        public User User { get; set; }
    }
}
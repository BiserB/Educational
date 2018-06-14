using System.ComponentModel.DataAnnotations;

namespace SimpleMvc.Domain
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int UserId { get; set; }

        [Required]
        public User Owner { get; set; }
    }
}
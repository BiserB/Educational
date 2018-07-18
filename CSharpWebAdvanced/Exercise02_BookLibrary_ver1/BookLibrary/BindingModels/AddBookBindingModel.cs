using System.ComponentModel.DataAnnotations;

namespace BookLibrary.BindingModels
{
    public class AddBookBindingModel
    {
        private const int MinLen = 2;
        private const int MaxLen = 255;
        //private const string MinLengthError = "Title can't be shorter than 2 characters";
        //private const string MaxLengthError = "The maximum length of Title is 255 characters.";

        [Required]
        [MinLength(MinLen)]
        [MaxLength(MaxLen)]
        public string Title { get; set; }

        [Required]
        [MinLength(MinLen)]
        [MaxLength(MaxLen)]
        public string AuthorName { get; set; }

        [Required]
        [MinLength(MinLen)]
        [MaxLength(MaxLen)]
        public string CategoryName { get; set; }

        [Required]
        [MinLength(MinLen)]
        [MaxLength(MaxLen)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string CoverImageUrl { get; set; }
    }
}
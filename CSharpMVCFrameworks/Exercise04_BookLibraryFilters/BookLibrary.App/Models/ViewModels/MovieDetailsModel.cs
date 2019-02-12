namespace BookLibrary.App.Models.ViewModels
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string DirectorName { get; set; }

        public string Description { get; set; }

        public string CoverImageUrl { get; set; }

        public string Status { get; set; }
    }
}
namespace BookLibrary.App.Models.ViewModels
{
    public class MovieShortInfoModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int DirectorId { get; set; }

        public string DirectorName { get; set; }

        public string Status { get; set; }
    }
}
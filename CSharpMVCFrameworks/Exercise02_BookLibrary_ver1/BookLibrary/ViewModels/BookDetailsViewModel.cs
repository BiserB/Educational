namespace BookLibrary.ViewModels

{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string CoverImageUrl { get; set; }
    }
}
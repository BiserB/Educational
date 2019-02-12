namespace Vote.App.Areas.Participant.Models
{
    public class ReplyViewModel
    {
        public string AuthorName { get; set; }

        public string Content { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }
    }
}
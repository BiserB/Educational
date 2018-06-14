namespace SimpleMvc.App.ViewModels
{
    public class UserProfileViewModel
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public IEnumerable<NoteViewModel> Notes { get; set; }
    }
}
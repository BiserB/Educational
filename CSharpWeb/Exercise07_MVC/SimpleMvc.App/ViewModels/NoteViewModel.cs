namespace SimpleMvc.App.ViewModels
{
    public class NoteViewModel
    {
        public NoteViewModel(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
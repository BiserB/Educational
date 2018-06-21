namespace SimpleMvc.App.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddNoteBindingModel
    {
        [MinLength(3)]
        public string Title { get; set; }

        [MinLength(5)]
        public string Content { get; set; }
    }
}
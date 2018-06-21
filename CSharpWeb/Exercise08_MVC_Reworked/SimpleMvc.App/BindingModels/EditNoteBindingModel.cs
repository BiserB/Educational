namespace SimpleMvc.App.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditNoteBindingModel
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Title { get; set; }

        [MinLength(5)]
        public string Content { get; set; }
    }
}
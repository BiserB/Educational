namespace MyTube.App.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class UploadTubeBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string YouTubeId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
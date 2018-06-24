
namespace FDMC.App.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddKittenBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 40)]
        public double Age { get; set; }

        public string Breed { get; set; }
    }
}

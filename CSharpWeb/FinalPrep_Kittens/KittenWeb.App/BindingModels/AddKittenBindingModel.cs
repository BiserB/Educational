
using System.ComponentModel.DataAnnotations;


namespace KittenWeb.App.BindingModels
{
    public class AddKittenBindingModel
    {
        [Required]
        public string Name { get; set; }
                
        public string BreedType { get; set; }

        public string Birthdate { get; set; }
    }
}

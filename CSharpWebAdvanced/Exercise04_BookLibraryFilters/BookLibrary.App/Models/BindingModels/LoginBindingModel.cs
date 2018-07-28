using System.ComponentModel.DataAnnotations;

namespace BookLibrary.App.Models.BindingModels
{
    public class LoginBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
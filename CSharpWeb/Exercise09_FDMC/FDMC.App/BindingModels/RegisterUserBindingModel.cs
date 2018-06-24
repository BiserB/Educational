
namespace FDMC.App.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

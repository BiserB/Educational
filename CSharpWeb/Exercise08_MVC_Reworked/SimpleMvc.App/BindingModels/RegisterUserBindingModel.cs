using System.ComponentModel.DataAnnotations;

namespace SimpleMvc.App.BindingModels
{
    public class RegisterUserBindingModel
    {
        [Required]
        public string Username { get; set; }

        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}")]
        public string Password { get; set; }
    }
}
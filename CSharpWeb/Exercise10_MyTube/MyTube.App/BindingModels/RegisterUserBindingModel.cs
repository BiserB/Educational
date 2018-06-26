namespace MyTube.App.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserBindingModel
    {
        [Required]
        [RegularExpression(@"\w{3,15}", ErrorMessage = "Must be between 3 and 15 characters letters and digits")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}", ErrorMessage = "Must be more then 6 characters, at least one lower case, one upper case and digit")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirm Password doesn't match.")]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
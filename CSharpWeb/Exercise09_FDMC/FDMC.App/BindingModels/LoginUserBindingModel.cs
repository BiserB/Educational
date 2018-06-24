
using System.ComponentModel.DataAnnotations;

namespace FDMC.App.BindingModels
{

    public class LoginUserBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

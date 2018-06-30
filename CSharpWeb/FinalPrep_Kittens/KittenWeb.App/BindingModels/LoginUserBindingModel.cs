using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KittenWeb.App.BindingModels
{
    public class LoginUserBindingModel
    {
        [Required]        
        public string Username { get; set; }

        [Required]        
        public string Password { get; set; }
    }
}

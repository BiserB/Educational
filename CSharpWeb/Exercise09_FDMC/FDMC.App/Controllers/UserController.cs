
namespace FDMC.App.Controllers
{
    using FDMC.App.BindingModels;
    using FDMC.App.Utils;
    using FDMC.Data;
    using FDMC.Models;
    using SimpleMVC.Framework.ActionResults;
    using SimpleMVC.Framework.Attributes.Methods;
    using SimpleMVC.Framework.Controllers;
    using SimpleMVC.Framework.Interfaces;
    using System.Linq;

    public class UserController: BaseController
    {
        [HttpGet]
        public IActionResult Register()
        {
            this.SetupLayoutHtml();

            this.Model["message"] = "";

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            this.SetupLayoutHtml();

            if (model.Password != model.ConfirmPassword)
            {
                this.Model["message"] = "Confirm password doesnt match";

                return View();
            }

            if (!IsValidModel(model))
            {
                this.Model["message"] = "Invalid data in the fields!";

                return View();
            }
            string passwordHash = PasswordUtilities.GetHash(model.Password);

            User user = new User(model.Username, passwordHash, model.Email);

            using (var db = new FDMCDbContext())
            {
                if (db.Users.Select(u => u.Username).Contains(user.Username))
                {
                    this.Model["message"] = "Username is allready taken!";

                    return View();
                }

                db.Users.Add(user);

                db.SaveChanges();              
            }

            return this.Login("Successful registration!");
        }

        [HttpGet]
        public IActionResult Login()
        {
            this.SetupLayoutHtml();

            this.Model["message"] = "";

            return View();
        }

        [HttpGet]
        public IActionResult Login(string message)
        {     
            this.Model["message"] = message;

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model)
        {
            this.SetupLayoutHtml();

            if (!IsValidModel(model))
            {
                this.Model["message"] = "Invalid data in the fields!";
            }

            using (var db = new FDMCDbContext())
            {
                string passwordHash = PasswordUtilities.GetHash(model.Password);

                bool userIsValid = db.Users.Any(u => u.Username == model.Username && u.Password == passwordHash);
                    
                if (!userIsValid)
                {                    
                    this.Model["message"] = "Invalid username or password!";

                    return View();
                }

                this.SignIn(model.Username);

                return new RedirectResult("/home/welcome");
            }
        }
                
        [HttpGet]
        public IActionResult Logout()
        {
            this.SetupLayoutHtml();

            this.SignOut();

            return new RedirectResult("/home/index");
        }
    }
}

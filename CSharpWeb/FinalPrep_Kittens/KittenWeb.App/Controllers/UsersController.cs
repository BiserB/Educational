
namespace KittenWeb.App.Controllers
{
    using KittenWeb.App.BindingModels;
    using KittenWeb.Data;
    using KittenWeb.Models;
    using SimpleMvc.Common;
    using SimpleMvc.Framework.ActionResults;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using System.Linq;

    public class UsersController: BaseController
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.Model["message"] = this.GetErrors();

                return this.View();
            }

            using (var db = new KittenWebDbContext())
            {
                string passwordHash = PasswordUtilities.GetPasswordHash(model.Password);

                User user = new User()
                {
                    Username = model.Username,
                    PasswordHash = passwordHash,
                    Email = model.Email
                };

                db.Users.Add(user);

                db.SaveChanges();

                this.Model["message"] = "<p>Successful registration!</p>";
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.Model["message"] = GetErrors();

                return this.View();
            }

            using (var db = new KittenWebDbContext())
            {
                string passwordHash = PasswordUtilities.GetPasswordHash(model.Password);

                User user = db.Users.FirstOrDefault(u => u.Username == model.Username &&
                                                         u.PasswordHash == passwordHash);

                if (user == null)
                {
                    this.Model["message"] = "<p>Invalid user or password</p>";

                    return this.View();
                }

                this.SignIn(user.Username, user.Id);                
            }

            return new RedirectResult("/home/welcome");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();

            return new RedirectResult("/home/index");
        }
    }
}

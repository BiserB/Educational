namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.App.Utils;
    using SimpleMvc.Domain;
    using SimpleMVC.Data;
    using SimpleMVC.Framework.ActionResults;
    using SimpleMVC.Framework.Attributes.Methods;
    using SimpleMVC.Framework.Controllers;
    using SimpleMVC.Framework.Interfaces;
    using System.Linq;
    using System.Text;

    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            this.Model["message"] = "";

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.Model["message"] = "Invalid data in the fields!";

                return this.View();
            }
            string username = model.Username;
            string passHash = PasswordUtilities.GetHash(model.Password);

            User user = new User(username, passHash);

            using (var db = new SimpleMVCDbContext())
            {
                if (!db.Users.Select(u => u.Username).Contains(username))
                {
                    db.Users.Add(user);

                    db.SaveChanges();

                    return this.Login("Successful registration!");
                }

                this.Model["message"] = "Username is allready taken!";
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            this.Model["message"] = "Enter your data";

            return View();
        }

        [HttpGet]
        public IActionResult Login(string message)
        {
            this.Model["message"] = message;

            return View();
        }

        [HttpPost]
        public IActionResult Login(RegisterUserBindingModel model)
        {
            string username = model.Username;

            string passHash = PasswordUtilities.GetHash(model.Password);

            using (var db = new SimpleMVCDbContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == passHash);

                if (user == null)
                {
                    this.Model["message"] = "Invalid username or password!";

                    return View();
                }

                this.SignIn(user.Username);
            }

            return new RedirectResult("/home/index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();

            return new RedirectResult("/home/index");
        }

        [HttpGet]
        public IActionResult Repository()
        {
            if (!this.User.IsAuthenticated)
            {
                return new RedirectResult("/home/index");
            }

            string username = this.User.Name;

            using (var db = new SimpleMVCDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    return this.Login("Sorry! User authentication error. Please try again!");
                }

                var notes = db.Notes.Where(n => n.UserId == user.Id && n.IsDeleted == false).ToList();

                StringBuilder sb = new StringBuilder();

                foreach (var note in notes)
                {
                    sb.AppendLine(string.Format(PartialViews.NoteView, note.Id, note.Title, note.Content));
                }

                string result = sb.ToString();

                this.Model["allNotes"] = result;
            }

            return View();
        }
    }
}
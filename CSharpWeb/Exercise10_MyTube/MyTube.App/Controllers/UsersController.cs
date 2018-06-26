namespace MyTube.App.Controllers
{
    using MyTube.App.BindingModels;
    using MyTube.App.Utils;
    using MyTube.Data;
    using MyTube.Models;
    using SimpleMvc.Framework.ActionResults;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using System.IO;
    using System.Linq;
    using System.Text;
    using WebServer.Http;

    public class UsersController : BaseController
    {
        [HttpGet]
        public IActionResult Register()
        {
            this.Model["message"] = "";

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

            using (var db = new MyTubeDbContext())
            {
                var user = new User();
                user.Username = model.Username;
                user.Password = model.Password;
                user.Email = model.Email;

                db.Users.Add(user);
                db.SaveChanges();
            }

            this.Model["message"] = "<p>Successful registration</p>";

            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            this.Model["message"] = "";

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.Model["message"] = this.GetErrors();

                return this.View();
            }

            using (var db = new MyTubeDbContext())
            {
                User user = db.Users
                    .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (user == null)
                {
                    this.Model["message"] = "<p>Invalid user or password</p>";

                    return this.View();
                }

                this.SignIn(user.Username, user.Id);
            }

            return new RedirectResult("/home/wellcome");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();

            return new RedirectResult("/home/index");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if (!this.User.IsAuthenticated)
            {
                return new RedirectResult("/users/login");
            }

            int userId = this.Request.Session.Get<int>(SessionStore.CurrentUserIdKey);

            using (var db = new MyTubeDbContext())
            {
                var userInfo = db.Users
                                 .Where(u => u.Id == userId)
                                 .Select(u => new { u.Username, u.Email })
                                 .First();

                var userTubes = db.Tubes
                                  .Where(t => t.UploaderId == userId)
                                  .Select(t => new { t.Id, t.Title, t.Author })
                                  .ToList();

                StringBuilder userTubesTable = new StringBuilder();

                string tableRow = File.ReadAllText(Paths.PartialViewsPath + "TableRow.html");

                int row = 0;

                foreach (var tube in userTubes)
                {
                    row++;

                    string rowFilled = string.Format(tableRow, row, tube.Title, tube.Author, tube.Id);

                    userTubesTable.AppendLine(rowFilled);
                }

                this.Model["userInfo"] = $"@{userInfo.Username}<br />({userInfo.Email})";
                this.Model["userTubes"] = userTubesTable.ToString();
            }

            return this.View();
        }
    }
}
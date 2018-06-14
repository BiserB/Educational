namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.App.Utils;
    using SimpleMvc.App.ViewModels;
    using SimpleMvc.Domain;
    using SimpleMVC.Data;
    using SimpleMVC.Framework.Attributes.Methods;
    using SimpleMVC.Framework.Controllers;
    using SimpleMVC.Framework.Interfaces;
    using SimpleMVC.Framework.Interfaces.Generic;
    using System.Collections.Generic;
    using System.Linq;

    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            string username = model.Username;
            string passHash = PasswordUtilities.GetHash(model.Password);

            User user = new User(username, passHash);

            using (var db = new SimpleMVCDbContext())
            {
                db.Users.Add(user);

                db.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public IActionResult<AllUsernamesViewModel> All()
        {
            List<string> usernames = null;

            using (var db = new SimpleMVCDbContext())
            {
                usernames = db.Users.Select(u => u.Username).ToList();
            }

            var viewModel = new AllUsernamesViewModel()
            {
                Usernames = usernames
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            return View();
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            User user = null;
            List<Note> notes = null;

            using (var db = new SimpleMVCDbContext())
            {
                user = db.Users.FirstOrDefault(u => u.Id == id);
                notes = db.Notes.Where(n => n.UserId == id).ToList();
            }

            var viewModel = new UserProfileViewModel()
            {
                UserId = user.Id,
                Username = user.Username,
                Notes = notes.Select(n => new NoteViewModel(n.Title, n.Content))
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var db = new SimpleMVCDbContext())
            {
                User user = db.Users.Find(model.UserId);

                Note note = new Note() { Title = model.Title, Content = model.Content };

                user.Notes.Add(note);

                db.SaveChanges();
            }

            return this.Profile(model.UserId);
        }
    }
}
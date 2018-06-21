namespace SimpleMvc.App.Controllers
{
    using SimpleMvc.App.BindingModels;
    using SimpleMvc.Domain;
    using SimpleMVC.Data;
    using SimpleMVC.Framework.ActionResults;
    using SimpleMVC.Framework.Attributes.Methods;
    using SimpleMVC.Framework.Controllers;
    using SimpleMVC.Framework.Interfaces;
    using System.Linq;

    public class NoteController : Controller
    {
        [HttpGet]
        public IActionResult New()
        {
            this.Model["message"] = "Write your note";

            return this.View();
        }

        [HttpPost]
        public IActionResult New(AddNoteBindingModel model)
        {
            if (!this.IsValidModel(model))
            {
                this.Model["message"] = "Can't save invalid note!";
            }
            else
            {
                using (var db = new SimpleMVCDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Username == this.User.Name);

                    if (user == null)
                    {
                        this.Model["message"] = "No such user!";

                        return View();
                    }

                    var note = new Note(model.Title, model.Content, user.Id);

                    user.Notes.Add(note);

                    db.SaveChanges();
                }

                this.Model["message"] = "Saved";
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            this.Model["message"] = "Editing";

            using (var db = new SimpleMVCDbContext())
            {
                var note = db.Notes.Find(Id);

                this.Model["Id"] = note.Id.ToString();
                this.Model["Title"] = note.Title;
                this.Model["Content"] = note.Content;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Edit(EditNoteBindingModel model)
        {
            using (var db = new SimpleMVCDbContext())
            {
                var note = db.Notes.Find(model.Id);

                note.Title = model.Title;
                note.Content = model.Content;

                db.SaveChanges();
            }
            return new RedirectResult("/user/repository");
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            using (var db = new SimpleMVCDbContext())
            {
                var note = db.Notes.Find(Id);

                note.IsDeleted = true;

                db.SaveChanges();
            }

            return new RedirectResult("/user/repository");
        }
    }
}
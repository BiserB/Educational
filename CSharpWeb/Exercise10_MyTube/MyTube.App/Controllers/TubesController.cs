namespace MyTube.App.Controllers
{
    using MyTube.App.BindingModels;
    using MyTube.Data;
    using MyTube.Models;
    using SimpleMvc.Framework.ActionResults;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using System.Linq;
    using WebServer.Http;

    public class TubesController : BaseController
    {
        [HttpGet]
        public IActionResult Upload()
        {
            if (!this.User.IsAuthenticated)
            {
                return new RedirectResult("/");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Upload(UploadTubeBindingModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return new RedirectResult("/");
            }

            if (!this.IsValidModel(model))
            {
                this.Model["message"] = this.GetErrors();

                return this.View();
            }

            var userId = this.Request.Session.Get<int>(SessionStore.CurrentUserIdKey);

            Tube tube = new Tube();
            tube.Title = model.Title;
            tube.Author = model.Author;
            tube.YouTubeId = model.YouTubeId;
            tube.Description = model.Description;
            tube.UploaderId = userId;

            using (var db = new MyTubeDbContext())
            {
                db.Tubes.Add(tube);

                db.SaveChanges();
            }

            this.Model["message"] = "<p>The Tube Successfully added</p>";

            return this.View();
        }

        [HttpGet]
        public IActionResult Details(int tubeId)
        {
            if (!this.User.IsAuthenticated)
            {
                return new RedirectResult("/");
            }

            using (var db = new MyTubeDbContext())
            {
                Tube tube = db.Tubes.FirstOrDefault(t => t.Id == tubeId);

                if (tube == null)
                {
                    return new RedirectResult("/");
                }

                tube.Views++;

                db.SaveChanges();

                this.Model["title"] = tube.Title;
                this.Model["tubeId"] = tube.YouTubeId;
                this.Model["author"] = tube.Author;
                this.Model["views"] = tube.Views.ToString();
                this.Model["desc"] = tube.Description;
            }

            return this.View();
        }
    }
}
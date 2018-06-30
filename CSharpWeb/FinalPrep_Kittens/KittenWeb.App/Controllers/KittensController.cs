
namespace KittenWeb.App.Controllers
{
    using KittenWeb.App.BindingModels;
    using KittenWeb.App.Utils;
    using KittenWeb.Data;
    using KittenWeb.Models;
    using Microsoft.EntityFrameworkCore;
    using SimpleMvc.Framework.ActionResults;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class KittensController: BaseController
    {
        [HttpGet]
        public IActionResult Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return new RedirectResult("/home/index");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddKittenBindingModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return new RedirectResult("/home/index");
            }

            if (!this.IsValidModel(model))
            {
                this.Model["message"] = this.GetErrors();

                return this.View();
            }

            using (var db = new KittenWebDbContext())
            {
                var breed = db.Breeds.FirstOrDefault(b => b.Type == model.BreedType);

                if (breed == null)
                {
                    this.Model["message"] = "<p>Unsupported breed!</p>";

                    return this.View();
                }

                DateTime birthdate = DateTime.Now;

                if (model.Birthdate == null || !DateTime.TryParse(model.Birthdate, out birthdate))
                {
                    this.Model["message"] = "<p>Unsupported date format!</p>";

                    return this.View();
                }

                Kitten kitten = new Kitten()
                {
                    Name = model.Name,
                    BreedId = breed.Id,
                    Birthdate = birthdate
                };

                db.Kittens.Add(kitten);

                db.SaveChanges();               
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.User.IsAuthenticated)
            {
                return new RedirectResult("/home/index");
            }

            StringBuilder result = new StringBuilder();

            using (var db = new KittenWebDbContext())
            {
                var kittens = db.Kittens                                
                                .Select(k => new{ k.Name, k.Breed, k.Birthdate, k.Breed.ImageUrl})
                                .ToList();

                var kittenViewTemplate = File.ReadAllText(Paths.PartialViewsPath + "KittenView.html");

                foreach (var kitten in kittens)
                {
                    var kittenView = String.Format(kittenViewTemplate, kitten.ImageUrl, kitten.Name, kitten.Birthdate, kitten.Breed);

                    result.AppendLine(kittenView);
                }

                this.Model["allKittens"] = result.ToString();
            }

            return this.View();
        }
    }
}

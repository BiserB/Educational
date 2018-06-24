
namespace FDMC.App.Controllers
{
    using FDMC.App.BindingModels;
    using FDMC.App.Utils;
    using FDMC.Data;
    using FDMC.Models;
    using SimpleMVC.Framework.Attributes.Methods;
    using SimpleMVC.Framework.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class KittenController: BaseController
    {
        [HttpGet]
        public IActionResult Add()
        {
            this.SetupLayoutHtml();

            this.Model["message"] = "Enter kitten details:";

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddKittenBindingModel model)
        {
            this.SetupLayoutHtml();

            Breed breed = 0;

            if (!IsValidModel(model) || !Enum.TryParse(model.Breed, out breed))
            {
                this.Model["message"] = "Invalid data in the fields";

                return this.View();
            }

            Kitten kitten = new Kitten(model.Name, model.Age, breed);

            using (var db = new FDMCDbContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Username == this.User.Name);

                kitten.OwnerId = user.Id;

                db.Cats.Add(kitten);

                db.SaveChanges();
            }

            this.Model["message"] = "Kitten added!";

            return this.View();
        }

        [HttpGet]
        public IActionResult All()
        {
            this.SetupLayoutHtml();

            using (var db = new FDMCDbContext())
            {
                List<Kitten> list = db.Cats.ToList();

                StringBuilder result = new StringBuilder();

                foreach (var kitten in list)
                {
                    string imageSource = PartialViews.ImageSource[(int)kitten.Breed];
                    string kittenView = String.Format(PartialViews.KittenView,
                                                                    imageSource,
                                                                    kitten.Name, 
                                                                    kitten.Age, 
                                                                    kitten.Breed.ToString());
                    result.AppendLine(kittenView);
                }

                this.Model["allKittens"] = result.ToString();
            }            

            return this.View();
        }
    }
}

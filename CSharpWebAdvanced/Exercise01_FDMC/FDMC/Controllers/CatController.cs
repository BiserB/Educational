using FDMC.Data;
using FDMC.Models.BaseModels;
using FDMC.Models.BindingModels;
using FDMC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using System.Linq;

namespace FDMC.Controllers
{
    public class CatController : BaseController
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCatBindingModel model)
        {
            if (!this.TryValidateModel(model))
            {
                ViewData["Message"] = "Error!";

                return View();
            }

            Cat cat = new Cat()
            {
                Name = model.Name,
                Age = model.Age,
                Breed = model.Breed,
                ImageUrl = model.ImageUrl
            };

            int id = 0;

            using (var db = new FDMCDbContext())
            {
                db.Cats.Add(cat);               

                db.SaveChanges();

                id = cat.Id;
            }

            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using (var db = new FDMCDbContext())
            {
                var cat = db.Cats.FirstOrDefault(c => c.Id == id);

                if (cat == null)
                {
                    ViewData["Message"] = "Error! There is no such cat!";

                    return View();
                }

                var catView = new CatView()
                {
                    Name = cat.Name,
                    Age = cat.Age,
                    Breed = cat.Breed,
                    ImageUrl = cat.ImageUrl
                };

                return View(catView);
            }            
        }
    }
}
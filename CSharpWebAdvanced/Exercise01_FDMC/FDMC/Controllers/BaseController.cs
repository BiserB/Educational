using FDMC.Data;
using FDMC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FDMC.Controllers
{
    public class BaseController : Controller
    {
        public List<CatView> AllCatsView()
        {
            using (var db = new FDMCDbContext())
            {
                var cats = db.Cats.Select(c => new CatView {
                                                            Name = c.Name,
                                                            Age = c.Age,
                                                            Breed = c.Breed,
                                                            ImageUrl = c.ImageUrl
                                                            })
                                                            .ToList();

                return cats;
            }
        }
    }
}
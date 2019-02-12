using BookLibrary.App.Models.ViewModels;
using BookLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookLibrary.App.Controllers
{
    public class DirectorsController : BaseController
    {
        public DirectorsController(BookLibraryDbContext db) : base(db)
        {
        }

        public IActionResult Details(int id)
        {
            var director = this.db.Directors.FirstOrDefault(d => d.Id == id);

            if (director == null)
            {
                return this.RedirectToPage("Message", new { msgId = 4 });
            }

            List<MovieShortInfoModel> movies = db.Movies
                                                 .Where(m => m.DirectorId == director.Id)
                                                 .Select(m => new MovieShortInfoModel()
                                                 {
                                                     Id = m.Id,
                                                     Title = m.Title,
                                                     Status = m.Status.Name
                                                 })
                                                 .ToList();

            var directorDetails = new DirectorDetailsModel()
            {
                DirectorName = director.Name,
                Movies = movies
            };

            return this.View(directorDetails);
        }
    }
}
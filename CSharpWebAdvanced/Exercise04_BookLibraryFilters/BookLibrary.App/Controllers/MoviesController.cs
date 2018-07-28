using BookLibrary.App.Filters;
using BookLibrary.App.Models.BindingModels;
using BookLibrary.App.Models.ViewModels;
using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookLibrary.App.Controllers
{
    [Authorize]
    public class MoviesController : BaseController
    {
        public MoviesController(BookLibraryDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(MovieBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var director = db.Directors.FirstOrDefault(a => a.Name == model.DirectorName);

            if (director == null)
            {
                director = new Director { Name = model.DirectorName };
                db.Directors.Add(director);
                db.SaveChanges();
            }

            var movie = new Movie()
            {
                Title = model.Title,
                DirectorId = director.Id,
                CoverImageUrl = model.CoverImageUrl,
                Description = model.Description
            };

            db.Movies.Add(movie);
            db.SaveChanges();

            return this.RedirectToAction("Details", new { id = movie.Id });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using (this.db)
            {
                var movie = db.Movies.Include(m => m.Director).FirstOrDefault(m => m.Id == id);

                if (movie == null)
                {
                    return this.RedirectToPage("Message", new { msgId = 3 });
                }

                string status = db.Statuses.Find(movie.StatusId).Name;

                var movieDetails = new MovieDetailsModel()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    DirectorName = movie.Director.Name,
                    Description = movie.Description,
                    CoverImageUrl = movie.CoverImageUrl,
                    Status = status
                };

                return this.View(movieDetails);
            }
        }

        [HttpGet]
        public IActionResult List()
        {
            using (this.db)
            {
                var movieList = db.Movies.Select(m => new MovieShortInfoModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    DirectorId = m.DirectorId,
                    DirectorName = m.Director.Name,
                    Status = m.Status.Name
                })
                .ToList();

                return this.View(movieList);
            }
        }
    }
}
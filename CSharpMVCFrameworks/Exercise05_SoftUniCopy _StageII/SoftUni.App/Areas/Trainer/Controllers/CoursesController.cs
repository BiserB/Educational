using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni.Common;
using SoftUni.Data;
using SoftUni.Models;
using SoftUni.Services.Trainer.Interfaces;

namespace SoftUni.App.Areas.Trainer.Controllers
{
    public class CoursesController : TrainerController
    {
        private IMapper mapper;
        private ITrainerCoursesService service;

        public CoursesController(SoftUniDbContext db, UserManager<User> userManager, IMapper mapper, ITrainerCoursesService service)
                          : base(db, userManager)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = this.service.GetTrainerPanelData();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(AddCourseBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            this.service.AddCourse(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var course = this.service.GetCourse(id);

            if (course == null)
            {
                return NotFound();
            }

            var viewModel = this.service.GetDetails(course);

            return View(viewModel);
        }
    }
}
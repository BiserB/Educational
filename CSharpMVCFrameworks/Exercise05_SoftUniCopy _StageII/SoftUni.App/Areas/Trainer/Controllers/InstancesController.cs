using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni.Common;
using SoftUni.Data;
using SoftUni.Models;
using SoftUni.Services.Trainer.Interfaces;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUni.App.Areas.Trainer.Controllers
{
    public class InstancesController : TrainerController
    {
        private readonly string ReturnUrl = "/trainer/courses/details/{0}";
        private readonly IMapper mapper;
        private readonly ITrainerInstancesService service;

        public InstancesController(SoftUniDbContext db, IMapper mapper, UserManager<User> userManager, ITrainerInstancesService service)
                            : base(db, userManager)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> AddInstance(int id)
        {
            var viewModel = await this.service.AddInstance(id);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddInstance(InstanceBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllTrainers = await this.service.GetTrainersAsync();

                return this.View(model);
            }

            var trainer = await this.service.GetTrainer(model.TrainerId);

            if (trainer == null)
            {
                ModelState.TryAddModelError("TrainerId", "Wrong Trainer");

                return this.View();
            }

            this.service.CreateInstance(model);

            return Redirect(string.Format(this.ReturnUrl, model.CourseId));
        }

        [HttpGet]
        public async Task<IActionResult> EditInstance(int id)
        {
            var instance = this.db.CourseInstances.FirstOrDefault(i => i.Id == id && i.IsDeleted == false);

            if (instance == null)
            {
                return NotFound();
            }

            var instanceView = this.mapper.Map<InstanceBindingModel>(instance);

            var model = new EditInstanceBindingModel
            {
                Instance = instanceView
            };

            model.Instance.InstanceId = id;

            model.Instance.AllTrainers = await this.GetTrainers();

            model.Lectures = this.db.Lectures
                                  .Where(l => l.InstanceId == id && l.IsDeleted == false)
                                  .Select(l => new InfoViewModel()
                                  {
                                      Name = l.Title,
                                      Id = l.Id
                                  })
                                  .ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditInstance(EditInstanceBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Instance.AllTrainers = await this.GetTrainers();

                return this.View(model);
            }

            var instance = this.db.CourseInstances
                .FirstOrDefault(i => i.Id == model.Instance.InstanceId && i.IsDeleted == false);

            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "dd/MM/yyyy";

            instance.Name = model.Instance.Name;
            instance.Description = model.Instance.Description;
            instance.StartDate = model.Instance.StartDate;
            //instance.EndDate = DateTime.ParseExact(model.Instance.EndDate, format, provider);
            instance.EndDate = model.Instance.EndDate;
            instance.TrainerId = model.Instance.TrainerId;

            this.db.SaveChanges();

            return Redirect(string.Format(this.ReturnUrl, model.Instance.CourseId));
        }

        [HttpGet]
        public IActionResult DeleteInstance(int id, int courseId)
        {
            var instance = this.db.CourseInstances.FirstOrDefault(i => i.Id == id);

            if (instance == null)
            {
                return NotFound();
            }

            instance.IsDeleted = true;

            db.SaveChanges();

            return Redirect(string.Format(this.ReturnUrl, courseId));
        }
    }
}
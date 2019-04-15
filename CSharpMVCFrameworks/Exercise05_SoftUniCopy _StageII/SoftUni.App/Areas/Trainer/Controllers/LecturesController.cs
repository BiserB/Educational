using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni.Common;
using SoftUni.Data;
using SoftUni.Models;
using System.Linq;

namespace SoftUni.App.Areas.Trainer.Controllers
{
    public class LecturesController : TrainerController
    {
        private readonly string ReturnUrl = "/trainer/instances/editinstance/{0}";
        private IMapper mapper;

        public LecturesController(SoftUniDbContext db, UserManager<User> userManager, IMapper mapper)
                            : base(db, userManager)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult AddLecture(int id)
        {
            this.ViewData["InstanceId"] = id;

            return View();
        }

        [HttpPost]
        public IActionResult AddLecture(LectureBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var lecture = this.mapper.Map<Lecture>(model);

            this.db.Lectures.Add(lecture);

            this.db.SaveChanges();

            return Redirect(string.Format(this.ReturnUrl, model.InstanceId));
        }

        [HttpGet]
        public IActionResult EditLecture(int id)
        {
            var lecture = this.db.Lectures.FirstOrDefault(l => l.Id == id && l.IsDeleted == false);

            if (lecture == null)
            {
                return NotFound();
            }

            var lectureModel = this.mapper.Map<LectureBindingModel>(lecture);

            var editLectureModel = new EditLectureBindingModel() { Lecture = lectureModel };

            editLectureModel.Lecture.LectureId = id;

            editLectureModel.Resources = this.db.Resources
                                                .Where(r => r.LectureId == id && r.IsDeleted == false)
                                                .Select(r => new InfoViewModel()
                                                {
                                                    Name = r.Title,
                                                    Id = r.Id
                                                })
                                                .ToList();

            return View(editLectureModel);
        }

        [HttpPost]
        public IActionResult EditLecture(EditLectureBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var lecture = this.db.Lectures.FirstOrDefault(l => l.Id == model.Lecture.LectureId && l.IsDeleted == false);

            if (lecture == null)
            {
                return NotFound();
            }

            lecture.Title = model.Lecture.Title;
            lecture.Description = model.Lecture.Description;
            lecture.StartTime = model.Lecture.StartTime;
            lecture.EndTime = model.Lecture.EndTime;
            lecture.LectureHall = model.Lecture.LectureHall;

            this.db.SaveChanges();

            return Redirect(string.Format(this.ReturnUrl, model.Lecture.InstanceId));
        }

        [HttpGet]
        public IActionResult DeleteLecture(int id, int instanceId)
        {
            var lecture = this.db.Lectures.FirstOrDefault(l => l.Id == id && l.IsDeleted == false);

            if (lecture == null)
            {
                return NotFound();
            }

            lecture.IsDeleted = true;

            db.SaveChanges();

            return Redirect(string.Format(this.ReturnUrl, instanceId));
        }
    }
}
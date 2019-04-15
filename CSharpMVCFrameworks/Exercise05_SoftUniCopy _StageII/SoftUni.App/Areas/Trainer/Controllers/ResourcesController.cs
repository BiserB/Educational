using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoftUni.Common;
using SoftUni.Data;
using SoftUni.Models;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni.App.Areas.Trainer.Controllers
{
    public class ResourcesController : TrainerController
    {
        private readonly string ReturnUrl = "/trainer/lectures/editlecture/{0}";
        private IMapper mapper;

        public ResourcesController(SoftUniDbContext db, UserManager<User> userManager, IMapper mapper)
                            : base(db, userManager)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult AddResource(int id)
        {
            var model = new ResourceBindingModel()
            {
                LectureId = id,
                ResourceTypes = this.GetResourceTypes()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddResource(ResourceBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var resource = this.mapper.Map<Resource>(model);

            this.db.Resources.Add(resource);

            this.db.SaveChanges();

            return Redirect(string.Format(this.ReturnUrl, model.LectureId));
        }

        [HttpGet]
        public IActionResult EditResource(int id, int lectureId)
        {
            var resource = this.db.Resources.FirstOrDefault(r => r.Id == id && r.IsDeleted == false);

            if (resource == null)
            {
                return NotFound();
            }

            var model = this.mapper.Map<ResourceBindingModel>(resource);

            model.ResourceTypes = this.GetResourceTypes();

            model.ResourceId = id;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditResource(ResourceBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var resource = this.db.Resources.FirstOrDefault(r => r.Id == model.ResourceId && r.IsDeleted == false);

            if (resource == null)
            {
                return NotFound();
            }

            resource.Title = model.Title;
            resource.ResourceUrl = model.ResourceUrl;
            resource.ResourceTypeId = model.ResourceTypeId;

            this.db.SaveChanges();

            return Redirect(string.Format(this.ReturnUrl, model.LectureId));
        }

        [HttpGet]
        public IActionResult DeleteResource(int id, int lectureId)
        {
            var resource = this.db.Resources.FirstOrDefault(r => r.Id == id && r.IsDeleted == false);

            if (resource == null)
            {
                return NotFound();
            }

            resource.IsDeleted = true;

            db.SaveChanges();

            return Redirect(string.Format(this.ReturnUrl, lectureId));
        }

        private List<SelectListItem> GetResourceTypes()
        {
            return db.ResourceTypes.Select(r => new SelectListItem()
            {
                Text = r.Name,
                Value = r.Id.ToString()
            })
                                               .ToList();
        }
    }
}
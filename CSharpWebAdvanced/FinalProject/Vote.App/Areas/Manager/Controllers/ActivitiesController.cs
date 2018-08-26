using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vote.Common.BindingModels;
using Vote.Common.ViewModels;
using Vote.Data;
using Vote.Entities;

namespace Vote.App.Areas.Manager.Controllers
{
    public class ActivitiesController : BaseManagerController
    {
        public ActivitiesController(VoteDbContext db, UserManager<User> userManager, IMapper mapper) 
            : base(db, userManager, mapper)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dbEvents = this.db.Events.ToList();

            var eventList = this.mapper.Map<List<EventViewModel>>(dbEvents);

            return View(eventList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateEventBindingModel();

            model.Code = "#1234";

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateEventBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var newEvent = this.mapper.Map<Event>(model);

            var userId = this.userManager.GetUserId(User);

            newEvent.CreatorId = userId;

            this.db.Events.Add(newEvent);

            this.db.SaveChanges();
            
            return LocalRedirect("/manager/activities/index");
        }
    }
}
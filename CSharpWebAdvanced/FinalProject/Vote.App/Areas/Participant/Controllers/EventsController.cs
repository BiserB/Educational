using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vote.App.Areas.Participant.Models;
using Vote.Common;
using Vote.Data;
using Vote.Entities;

namespace Vote.App.Areas.Participant.Controllers
{
    public class EventsController : BaseParticipantController
    {
        public EventsController(VoteDbContext db, UserManager<User> userManager) : base(db, userManager)
        {

        }

        [HttpGet]
        public IActionResult Join(string code)
        {
            if (code == null)
            {
                return LocalRedirect("~/");
            }

            var dbEvent = this.db.Events.FirstOrDefault(e => e.Code == code);

            if (dbEvent == null)
            {
                return LocalRedirect("~/NoResult");
            }

            var questions = this.db.Questions
                                   .Where(q => q.EventId == dbEvent.Id)
                                   .Select(q => new QuestionViewModel()
                                   {
                                       AuthorName = q.Author.UserName,
                                       Content = q.Content,
                                       Upvotes = q.Upvotes,
                                       PublishedOn = q.PublishedOn,
                                       Doqwnvotes = q.Downvotes,
                                       Replies = q.Replies
                                                  .Select(r => new ReplyViewModel()
                                                  {
                                                      AuthorName = r.Author.UserName,
                                                      Content = r.Content,
                                                      Upvotes = r.Upvotes,
                                                      Downvotes = r.Downvotes
                                                  }).ToList()
                                   })
                                   .ToList();


            var joinModel = new JoinEventViewModel()
            {
                EventId = dbEvent.Id,
                EventTitle = dbEvent.Title,
                EventCode = dbEvent.Code
            };

            joinModel.Questions = questions;

            joinModel.IsAnonimous = true;

            if (this.User.IsInRole(RoleType.Manager))
            {
                joinModel.ParticipantId = this.userManager.GetUserId(User);
            }

            return View(joinModel);
        }

        [HttpPost]
        public async Task<IActionResult> Ask(JoinEventViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Join", new { code = model.EventCode});
            }

            var question = new Question()
            {
                EventId = model.EventId,
                Content = model.Content,
                PublishedOn = DateTime.Now
            };

            if (model.ParticipantId == null)
            {
                var anonimous = await userManager.FindByNameAsync("Anonimous");

                question.AuthorId = anonimous.Id;
            }
            else
            {
                question.AuthorId = model.ParticipantId;
            }

            this.db.Questions.Add(question);

            this.db.SaveChanges();

            return RedirectToAction("Join", new { code = model.EventCode });
        }
    }
}
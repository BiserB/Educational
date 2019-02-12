using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vote.Common;
using Vote.Data;
using Vote.Entities;

namespace Vote.App.Areas.Participant.Controllers
{
    [Area(RoleType.Participant)]
    public class BaseParticipantController : Controller
    {
        protected VoteDbContext db;
        protected UserManager<User> userManager;

        public BaseParticipantController(VoteDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
    }
}
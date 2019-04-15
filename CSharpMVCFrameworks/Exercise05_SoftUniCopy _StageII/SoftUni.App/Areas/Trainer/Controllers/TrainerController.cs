using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoftUni.Common.Settings;
using SoftUni.Data;
using SoftUni.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUni.App.Areas.Trainer.Controllers
{
    [Area(RoleType.Trainer)]
    [Authorize(Roles = RoleType.Trainer + "," + RoleType.Admin + "," + RoleType.SysAdmin)]
    public abstract class TrainerController : Controller
    {
        protected readonly SoftUniDbContext db;
        protected readonly UserManager<User> userManager;

        public TrainerController(SoftUniDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        protected async Task<List<SelectListItem>> GetTrainers()
        {
            var dbTrainers = await this.userManager.GetUsersInRoleAsync(RoleType.Trainer);

            var trainers = dbTrainers.Select(t => new SelectListItem
            {
                Text = t.FullName,
                Value = t.Id
            })
            .ToList();

            return trainers;
        }
    }
}
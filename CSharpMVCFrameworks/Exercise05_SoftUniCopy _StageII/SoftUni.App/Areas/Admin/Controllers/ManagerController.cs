using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using SoftUni.Common.Settings;
using SoftUni.Data;
using SoftUni.Models;
using System.Linq;

namespace SoftUni.App.Areas.Admin.Controllers
{
    public class ManagerController : AdminController
    {
        private UserManager<User> userManager;

        public ManagerController(UserManager<User> manager, SoftUniDbContext db) : base(db)
        {
            this.userManager = manager;
        }

        [HttpGet]
        public IActionResult Panel()
        {
            ViewData["Students"] = userManager.GetUsersInRoleAsync(RoleType.Student).Result.Count;
            ViewData["Trainers"] = userManager.GetUsersInRoleAsync(RoleType.Trainer).Result.Count;
            ViewData["Admins"] = userManager.GetUsersInRoleAsync(RoleType.Admin).Result.Count;
            ViewData["All"] = userManager.Users.Count();

            return this.View();
        }
    }
}
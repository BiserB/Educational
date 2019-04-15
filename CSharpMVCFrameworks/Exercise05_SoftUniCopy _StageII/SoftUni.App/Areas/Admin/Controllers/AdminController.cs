using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUni.Common.Settings;
using SoftUni.Data;

namespace SoftUni.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleType.SysAdmin + "," + RoleType.Admin)]
    public abstract class AdminController : Controller
    {
        protected readonly SoftUniDbContext db;

        public AdminController(SoftUniDbContext db)
        {
            this.db = db;
        }
    }
}
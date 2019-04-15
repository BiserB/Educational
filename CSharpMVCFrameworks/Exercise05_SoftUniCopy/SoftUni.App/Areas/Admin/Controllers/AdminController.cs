using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUni.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUni.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public abstract class AdminController : Controller
    {
        protected readonly SoftUniDbContext db;

        public AdminController(SoftUniDbContext db)
        {
            this.db = db;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUni.App.Areas.Admin.Controllers
{    
    public class ManagerController : AdminController
    {
        public ManagerController(SoftUniDbContext db) : base(db)
        {

        }

        public IActionResult Panel()
        {            
            return this.View();
        }
    }
}

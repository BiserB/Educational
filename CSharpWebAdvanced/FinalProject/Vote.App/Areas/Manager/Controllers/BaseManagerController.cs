using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vote.Common;
using Vote.Data;
using Vote.Entities;

namespace Vote.App.Areas.Manager.Controllers
{
    [Area(RoleType.Manager)]
    [Authorize(Roles = RoleType.Manager + "," + RoleType.Admin + "," + RoleType.SysAdmin)]
    public abstract class BaseManagerController : Controller
    {
        protected readonly VoteDbContext db;
        protected readonly UserManager<User> userManager;
        protected readonly IMapper mapper;

        public BaseManagerController(VoteDbContext db, UserManager<User> userManager, IMapper mapper)
        {
            this.db = db;
            this.userManager = userManager;
            this.mapper = mapper;
        }
    }
}

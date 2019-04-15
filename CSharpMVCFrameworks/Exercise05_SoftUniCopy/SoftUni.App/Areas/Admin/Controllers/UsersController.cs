using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni.App.Areas.Admin.Models.ViewModels;
using SoftUni.App.Common;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUni.App.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        private IMapper mapper;
        private UserManager<User> userManager;

        public UsersController(SoftUniDbContext db, IMapper mapper, UserManager<User> manager): base(db)
        {
            this.mapper = mapper;
            this.userManager = manager;
        }

        [HttpGet]
        public IActionResult UsersList()
        {
            var dbUsers = this.db.Users.ToList();

            var users = this.mapper.Map<IEnumerable<UserInfoModel>>(dbUsers);

            return this.View(users);
        }

        [HttpGet]
        public async Task<IActionResult> UserDetails(string id)
        {
            var dbUser = this.db.Users.FirstOrDefault(u => u.Id == id);

            if (dbUser == null)
            {
                this.ViewData["Message"] = "No such user!";

                return this.View();
            }

            var role = RoleType.Student;

            var roles = await this.userManager.GetRolesAsync(dbUser);

            if (roles.Count > 0)
            {
                role = roles.First();
            }

            var user = this.mapper.Map<UserDetailsModel>(dbUser);

            user.Role = role;

            return this.View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var dbUser = this.db.Users.FirstOrDefault(u => u.Id == id);

            if (dbUser == null)
            {
                this.ViewData["Message"] = "No such user!";

                return this.View();
            }

            var user = this.mapper.Map<UserDetailsModel>(dbUser);

            var role = RoleType.Student;

            var roles = await this.userManager.GetRolesAsync(dbUser);

            if (roles.Count > 0)
            {
                role = roles.First();
            }

            user.Role = role;

            return this.View(user);
        }

        [HttpPost]
        public IActionResult EditUser(UserDetailsModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData["Message"] = "Invalid data!";

                return this.View();
            }

            var user = this.db.Users.FirstOrDefault(u => u.Id == model.Id);

            if (user == null)
            {
                this.ViewData["Message"] = "No such user!";

                return this.View();
            }

            user.FullName = model.FullName;
            user.Email = model.Email;            
            user.EmailConfirmed = model.EmailConfirmed;
            user.PasswordHash = model.PasswordHash;
            user.PhoneNumber = model.PhoneNumber;

            var roleId = db.Roles.First(r => r.Name == model.Role).Id;

            var userRole = db.UserRoles.First(ur => ur.UserId == model.Id);

            userRole.RoleId = roleId;

            this.db.SaveChanges();

            return Redirect($"/Admin/Users/UserDetails?id={model.Id}");
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftUni.Common;
using SoftUni.Common.Settings;
using SoftUni.Data;
using SoftUni.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUni.App.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        private IMapper mapper;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UsersController(SoftUniDbContext db, IMapper mapper, UserManager<User> manager, RoleManager<IdentityRole> roleManager) : base(db)
        {
            this.mapper = mapper;
            this.userManager = manager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult UsersList(string role)
        {
            List<User> list = new List<User>();

            string title = "all users";

            switch (role)
            {
                case RoleType.Student:
                    title = "students";
                    list = userManager.GetUsersInRoleAsync(RoleType.Student).Result.ToList();
                    break;

                case RoleType.Trainer:
                    title = "trainers";
                    list = userManager.GetUsersInRoleAsync(RoleType.Trainer).Result.ToList();
                    break;

                case RoleType.Admin:
                    title = "administrators";
                    list = userManager.GetUsersInRoleAsync(RoleType.Admin).Result.ToList();
                    break;

                default:
                    list = userManager.Users.ToList();
                    break;
            }

            ViewData["Users"] = title;

            var users = this.mapper.Map<IEnumerable<UserInfoModel>>(list);

            return this.View(users);
        }

        [HttpGet]
        public async Task<IActionResult> UserDetails(string id)
        {
            if (await this.UserIsHidden(id))
            {
                this.ViewData["Message"] = "Cannot show this user!";

                return this.View();
            }

            var dbUser = this.db.Users.FirstOrDefault(u => u.Id == id);

            if (dbUser == null)
            {
                this.ViewData["Message"] = "No such user!";

                return this.View();
            }

            var roles = await this.userManager.GetRolesAsync(dbUser);

            var userModel = this.mapper.Map<UserDetailsModel>(dbUser);

            if (roles.Count > 0)
            {
                userModel.Role = roles.First();
            }

            return this.View(userModel);
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

            user.AllRoles = this.db.Roles.Select(r => r.Name).ToList();

            var userRoles = await this.userManager.GetRolesAsync(dbUser);

            user.Role = userRoles.First();

            return this.View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserDetailsModel model)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData["Message"] = "Invalid data!";

                return this.View();
            }

            if (await this.UserIsHidden(model.Id))
            {
                this.ViewData["Message"] = "Cannot show this user!";

                return this.View();
            }

            var user = this.userManager.Users.FirstOrDefault(u => u.Id == model.Id);

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

            var oldRole = (await this.userManager.GetRolesAsync(user)).FirstOrDefault();

            var newRole = model.AllRoles.First();

            if (oldRole != null && newRole != oldRole)
            {
                userManager.RemoveFromRoleAsync(user, oldRole).Wait();
            }

            var roleExist = this.roleManager.RoleExistsAsync(newRole).Result;

            if (roleExist)
            {
                userManager.AddToRoleAsync(user, newRole).Wait();
            }

            return Redirect($"/Admin/Users/UserDetails?id={model.Id}");
        }

        private async Task<bool> UserIsHidden(string id)
        {
            var sysAdminRoleId = roleManager.Roles.First(r => r.Name == RoleType.SysAdmin).Id;

            var wantedUser = await userManager.FindByIdAsync(id);

            var wantedUserIsSysAdmin = await userManager.IsInRoleAsync(wantedUser, RoleType.SysAdmin);

            if (wantedUserIsSysAdmin)
            {
                return true;
            }

            return false;
        }
    }
}
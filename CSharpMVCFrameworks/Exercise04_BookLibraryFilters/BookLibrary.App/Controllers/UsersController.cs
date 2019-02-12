using BookLibrary.App.Auxiliary;
using BookLibrary.App.Models.BindingModels;
using BookLibrary.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookLibrary.App.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(BookLibraryDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                this.ViewData["Message"] = "Invalid fields!";

                return RedirectToAction("Login", "Users");
            }

            string username = model.Username;
            string passHash = PasswordUtilities.GetHash(model.Password);
            string cookieValue = Guid.NewGuid().ToString();

            var user = db.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == passHash);

            if (user == null)
            {
                this.ViewData["Message"] = "Wrong username or password!";

                return RedirectToAction("Login", "Users");
            }

            this.SetCookie(SessionKeys.UserKey, cookieValue, 100);

            this.HttpContext.Session.SetString(cookieValue, SessionKeys.UserKey);

            return this.RedirectToPage("/Index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            string cookieValue = this.Request.Cookies[SessionKeys.UserKey];

            if (cookieValue != null)
            {
                this.HttpContext.Session.Remove(cookieValue);
            }

            return RedirectToPage("/Index");
        }

        private void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
            {
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            }
            else
            {
                option.Expires = DateTime.Now.AddMilliseconds(10);
            }

            Response.Cookies.Append(key, value, option);
        }
    }
}
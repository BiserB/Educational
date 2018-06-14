namespace HTTPServer.GameStoreApp.Controllers
{
    using HTTPServer.GameStoreApp.Data;
    using HTTPServer.GameStoreApp.Infrastructure;
    using HTTPServer.GameStoreApp.Models;
    using HTTPServer.GameStoreApp.Utilities;
    using HTTPServer.Server.Http;
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Server.Http.Response;
    using System;
    using System.Linq;

    public class AccountController : Controller
    {
        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"\login");
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            var formData = req.FormData;

            if (!formData.ContainsKey(Config.FormEmail) || !formData.ContainsKey(Config.FormPassword))
            {
                return new BadRequestResponse();
            }

            string email = req.FormData[Config.FormEmail];
            string password = req.FormData[Config.FormPassword];

            if (HasWrongFields(email, password))
            {
                return this.FileViewResponse(@"login");
            }

            string passwordHash = PasswordUtilities.GetHash(password);
            int userId = 0;

            using (var db = new GameStoreDbContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Email == email);

                if (user == null || user.PasswordHash != passwordHash)
                {
                    UserOrPasswordError();
                    return this.FileViewResponse(@"login");
                }
                userId = user.Id;

                if (user.IsAdmin)
                {
                    req.Session.Add(SessionStore.AdminKey, userId);
                }
            }

            req.Session.Add(SessionStore.CurrentUserKey, userId);

            return new RedirectResponse("/");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/");
        }

        public IHttpResponse Register()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"register");
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            var formData = request.FormData;

            if (!formData.ContainsKey(Config.FormEmail) || !formData.ContainsKey(Config.FormFullName) ||
                !formData.ContainsKey(Config.FormPassword) || !formData.ContainsKey(Config.FormConfirmPass))
            {
                return new BadRequestResponse();
            }

            string email = formData[Config.FormEmail];
            string fullName = formData[Config.FormFullName];
            string password = formData[Config.FormPassword];
            string confirm = formData[Config.FormConfirmPass];

            if (HasWrongFields(email, fullName, password, confirm))
            {
                return this.FileViewResponse(@"register");
            }

            if (password != confirm)
            {
                this.ViewData["error"] = "Password does not match the confirm password.";
                this.ViewData["showError"] = "block";
                return this.FileViewResponse(@"register");
            }

            string passwordHash = PasswordUtilities.GetHash(password);

            User user = new User(fullName, email, passwordHash);

            using (var db = new GameStoreDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return new RedirectResponse(@"login");
        }

        private bool HasWrongFields(params string[] fields)
        {
            foreach (var field in fields)
            {
                if (String.IsNullOrWhiteSpace(field) ||
                    field.Length < Config.FieldMinLength ||
                    field.Length > Config.FieldMaxLength)
                {
                    WrongFieldError();
                    return true;
                }
            }
            return false;
        }

        private void UserOrPasswordError()
        {
            this.ViewData["error"] = "Wrong user or password";
            this.ViewData["showError"] = "block";
        }

        private void WrongFieldError()
        {
            this.ViewData["error"] = "You have wrong fields";
            this.ViewData["showError"] = "block";
        }
    }
}
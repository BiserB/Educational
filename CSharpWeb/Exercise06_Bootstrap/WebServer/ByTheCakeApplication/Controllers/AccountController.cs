namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using HTTPServer.ByTheCakeApplication.Data;
    using HTTPServer.ByTheCakeApplication.Utilities;
    using Infrastructure;
    using Models;
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using System;
    using System.Linq;

    public class AccountController : Controller
    {
        public IHttpResponse Register()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\register");
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            var formData = request.FormData;

            const string formNameKey = "name";
            const string formUsernameKey = "username";
            const string formPassKey = "password";
            const string formConfirmKey = "confirm";

            if (!formData.ContainsKey(formNameKey) || !formData.ContainsKey(formPassKey) ||
                !formData.ContainsKey(formUsernameKey) || !formData.ContainsKey(formConfirmKey))
            {
                return new BadRequestResponse();
            }

            string name = formData[formNameKey];
            string username = formData[formUsernameKey];
            string password = formData[formPassKey];
            string confirm = formData[formConfirmKey];

            if (HasWrongFields(name, username, password, confirm))
            {
                return this.FileViewResponse(@"account\register");
            }

            if (password != confirm)
            {
                this.ViewData["error"] = "Password does not match the confirm password.";
                this.ViewData["showError"] = "block";
                return this.FileViewResponse(@"account\register");
            }

            string passwordHash = PasswordUtilities.GetHash(password);

            User user = new User(name, username, passwordHash, DateTime.UtcNow);

            using (var db = new ByTheCakeDbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return new RedirectResponse(@"/login");
        }

        public IHttpResponse Profile(IHttpRequest req)
        {
            int userId = req.Session.Get<int>(SessionStore.CurrentUserKey);

            using (var db = new ByTheCakeDbContext())
            {
                User user = db.Users.Find(userId);
                var orders = db.Orders.Where(o => o.UserId == user.Id).Count();

                this.ViewData["name"] = user.Name;
                this.ViewData["registeredOn"] = user.RegisteredOn.ToString("dd-MM-yyyy");
                this.ViewData["orders"] = orders.ToString();
            }
            return this.FileViewResponse(@"account\profile");
        }

        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\login");
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            const string formNameKey = "username";
            const string formPasswordKey = "password";
            var formData = req.FormData;

            if (!formData.ContainsKey(formNameKey) || !formData.ContainsKey(formPasswordKey))
            {
                return new BadRequestResponse();
            }

            string username = req.FormData[formNameKey];
            string password = req.FormData[formPasswordKey];

            if (HasWrongFields(username, password))
            {
                return this.FileViewResponse(@"account\login");
            }

            string passwordHash = PasswordUtilities.GetHash(password);
            int userId = 0;

            using (var db = new ByTheCakeDbContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Username == username);
                if (user == null || user.PasswordHash != passwordHash)
                {
                    UserOrPasswordError();
                    return this.FileViewResponse(@"account\login");
                }
                userId = user.Id;
            }

            req.Session.Add(SessionStore.CurrentUserKey, userId);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            return new RedirectResponse("/");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/login");
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

        private void WrongFieldError()
        {
            this.ViewData["error"] = "You have wrong fields";
            this.ViewData["showError"] = "block";
        }

        private void UserOrPasswordError()
        {
            this.ViewData["error"] = "Wrong user or password";
            this.ViewData["showError"] = "block";
        }
    }
}
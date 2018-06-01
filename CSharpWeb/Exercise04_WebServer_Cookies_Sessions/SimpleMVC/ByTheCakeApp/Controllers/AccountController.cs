
using System;
using System.Collections.Generic;
using SimpleMVC.ByTheCakeApp.Views;
using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Enums;
using SimpleMVC.Server.HTTP.Response;

namespace SimpleMVC.ByTheCakeApp.Controllers
{
    public class AccountController
    {
        public IHttpResponse Login()
        {
            var response = new ViewResponse(HttpStatusCode.OK, new LoginView());

            return response;
        }

        public IHttpResponse Login(Dictionary<string, string> formData)
        {
            string username = formData["username"];
            string password = formData["password"];

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return new RedirectResponse("/login");
            }

            return new RedirectResponse("/"); ;
        }
    }
}

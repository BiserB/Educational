
using System;
using System.Collections.Generic;
using SimpleMVC.ByTheCakeApp.Data;
using SimpleMVC.ByTheCakeApp.Views;
using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Enums;
using SimpleMVC.Server.HTTP;
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

        public IHttpResponse Login(IHttpRequest request)
        {
            string username = request.FormData["username"];
            string password = request.FormData["password"];

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return new RedirectResponse("/login");
            }

            string sessionId = request.Session.Id;

            SessionStore.Get(sessionId).ChangeState(true);

            ShoppingCartStorage.GetOrAddCart(sessionId);

            return new RedirectResponse("/");
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            string sessionId = request.Session.Id;

            ShoppingCartStorage.DeleteCart(sessionId);

            SessionStore.DeleteSession(sessionId);

            return new RedirectResponse("/login");
        }

    }
}

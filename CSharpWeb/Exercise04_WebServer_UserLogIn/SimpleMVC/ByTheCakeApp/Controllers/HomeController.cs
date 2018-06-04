using System;
using SimpleMVC.ByTheCakeApp.Views;
using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Enums;
using SimpleMVC.Server.HTTP.Response;

namespace SimpleMVC.ByTheCakeApp.Controllers
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            var response = new ViewResponse(HttpStatusCode.OK, new HomeView());

            return response;
        }

        public IHttpResponse About()
        {
            var response = new ViewResponse(HttpStatusCode.OK, new AboutView());

            return response;
        }
    }
}

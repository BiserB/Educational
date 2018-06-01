using SimpleMVC.Application.Views;
using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Enums;
using SimpleMVC.Server.HTTP;
using SimpleMVC.Server.HTTP.Response;
using System;

namespace SimpleMVC.Application.Controllers
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            var response = new ViewResponse(HttpStatusCode.OK, new HomeView());

            response.AddCookie(new HttpCookie("lang", "en"));

            return response;
        }

        public IHttpResponse SessionTest(IHttpRequest request)
        {
            IHttpSession session = request.Session;

            if (session.GetParameter("Logged_in") == null)
            {
                session.Add("Logged_in", DateTime.UtcNow);                
            }

            DateTime loggedInTime = (DateTime)session.GetParameter("Logged_in");

            var response = new ViewResponse(HttpStatusCode.OK, new SessionTestView(loggedInTime));            

            return response;
        }
    }
}
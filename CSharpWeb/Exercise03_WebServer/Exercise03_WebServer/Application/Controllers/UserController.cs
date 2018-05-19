using Exercise03_WebServer.Application.Views;
using Exercise03_WebServer.Server;
using Exercise03_WebServer.Server.Enums;
using Exercise03_WebServer.Server.HTTP.Contracts;
using Exercise03_WebServer.Server.HTTP.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Application.Controllers
{
    public class UserController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new RegisterView());
        }

        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public IHttpResponse Details(string name)
        {
            Model model = new Model { ["name"] = name };

            return new ViewResponse(HttpStatusCode.OK, new UserDetailsView(model));
        }
    }
}

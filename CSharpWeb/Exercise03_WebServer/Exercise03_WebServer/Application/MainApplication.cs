using Exercise03_WebServer.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Exercise03_WebServer.Server.Routing.Contracts;
using Exercise03_WebServer.Server.Handlers;
using Exercise03_WebServer.Application.Controllers;

namespace Exercise03_WebServer.Application
{
    public class MainApplication : IApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            //appRouteConfig.AddRoute("/", new GetHandler(request => new HomeController().Index()));

            appRouteConfig.AddRoute("/register",
                new PostHandler(httpContext => new UserController()
                .RegisterPost(httpContext.FormData["name"])));

            appRouteConfig.AddRoute("/register",
                new GetHandler(httpContext => new UserController()
                .RegisterGet()));

            //appRouteConfig.AddRoute("/user/{(?<name>[a-z]+)}",
            //    new GetHandler(httpContext => new UserController()
            //    .Details(httpContext.UrlParameters["name"])));
        }
    }
}

using SimpleWebServer.Server.Contracts;

using SimpleWebServer.Server.Routing.Contracts;
using SimpleWebServer.Server.Handlers;
using SimpleWebServer.Application.Controllers;

namespace SimpleWebServer.Application
{
    public class MainApplication : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AddRoute("/", new GetHandler(request => new HomeController().Index()));

            appRouteConfig.AddRoute("/register",
                new PostHandler(httpContext => new UserController()
                .RegisterPost(httpContext.FormData["name"])));

            appRouteConfig.AddRoute("/register",
                new GetHandler(httpContext => new UserController()
                .RegisterGet()));

            appRouteConfig.AddRoute("/user/{(?<name>[a-z]+)}",
                new GetHandler(httpContext => new UserController()
                .Details(httpContext.UrlParameters["name"])));
        }
    }
}

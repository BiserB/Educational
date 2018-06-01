using SimpleMVC.Application.Controllers;
using SimpleMVC.Server.Contracts;

namespace SimpleMVC.Application
{
    public class MainApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get("/", request => new HomeController().Index());

            appRouteConfig.Get("/test", request => new HomeController().SessionTest(request));

            appRouteConfig.Get("/register", request => new UserController()
                          .RegisterGet());

            appRouteConfig.Post("/register", request => new UserController()
                          .RegisterPost(request.FormData["name"]));

            appRouteConfig.Get("/user/{(?<name>[a-z]+)}", request => new UserController()
                          .Details(request.UrlParameters["name"]));
        }
    }
}
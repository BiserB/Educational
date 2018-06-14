namespace HTTPServer.ByTheCakeApplication
{
    using Controllers;
    using HTTPServer.ByTheCakeApplication.Data;
    using Microsoft.EntityFrameworkCore;
    using Server.Contracts;
    using Server.Routing.Contracts;

    public class ByTheCakeApp : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            var dbContext = new ByTheCakeDbContext();
            dbContext.Database.Migrate();

            appRouteConfig
                .Get("/", req => new HomeController().Index());

            appRouteConfig
                .Get("/about", req => new HomeController().About());

            appRouteConfig
                .Get("/add", req => new CakesController().Add());

            appRouteConfig
                .Post("/add",
                    req => new CakesController().Add(req));

            appRouteConfig
                .Get("/search",
                    req => new CakesController().Search(req));

            appRouteConfig
                .Get("/details/{(?<id>[0-9]+)}",
                    req => new CakesController().Details(req));

            appRouteConfig
                .Get("/register",
                    req => new AccountController().Register());

            appRouteConfig
                .Post("/register",
                    req => new AccountController().Register(req));

            appRouteConfig
                .Get("/login",
                    req => new AccountController().Login());

            appRouteConfig
                .Post("/login",
                    req => new AccountController().Login(req));

            appRouteConfig
                .Post("/logout",
                    req => new AccountController().Logout(req));

            appRouteConfig
                .Get("/profile",
                    req => new AccountController().Profile(req));

            appRouteConfig
                .Get("/orders",
                    req => new ShoppingController().UserOrders(req));

            appRouteConfig
                .Get("/orders/{(?<id>[0-9]+)}",
                    req => new ShoppingController().OrderDetails(req));

            appRouteConfig
                .Get("/shopping/add/{(?<id>[0-9]+)}",
                    req => new ShoppingController().AddToCart(req));

            appRouteConfig
                .Get("/cart",
                    req => new ShoppingController().ShowCart(req));

            appRouteConfig
                .Post("/shopping/finish-order",
                    req => new ShoppingController().FinishOrder(req));

            appRouteConfig
                .Get("/Images/{(?<filename>(\\w+\\-*\\w+).(jpeg|jpg|gif|bmp|png))}",
                    req => new ResourcesController().GetFile(req));

            appRouteConfig
                .Get("/Files/{(?<filename>(\\w+\\-*\\w+).(css|js))}",
                    req => new ResourcesController().GetFile(req));
        }
    }
}
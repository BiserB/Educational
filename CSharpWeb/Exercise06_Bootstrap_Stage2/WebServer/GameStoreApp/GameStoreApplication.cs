namespace HTTPServer.GameStoreApp
{
    using HTTPServer.GameStoreApp.Controllers;
    using HTTPServer.GameStoreApp.Data;
    using HTTPServer.Server.Routing;
    using Microsoft.EntityFrameworkCore;

    public class GameStoreApplication
    {
        public void Configure(AppRouteConfig appRouteConfig)
        {
            ConfigureDatabase();

            appRouteConfig.Get("/", req => new HomeController().Index(req));

            appRouteConfig.Get("/owned", req => new HomeController().Index(req));

            appRouteConfig.Get("/login", req => new AccountController().Login());

            appRouteConfig.Post("/login", req => new AccountController().Login(req));

            appRouteConfig.Get("/logout", req => new AccountController().Logout(req));

            appRouteConfig.Get("/register", req => new AccountController().Register());

            appRouteConfig.Post("/register", req => new AccountController().Register(req));

            appRouteConfig.Get("/add", req => new GameController().GetAddForm(req));

            appRouteConfig.Post("/add", req => new GameController().Add(req));

            appRouteConfig.Get("/list", req => new GameController().ListAllGames(req));

            appRouteConfig.Get("/info/{(?<gameId>\\d+)}", req => new GameController().Info(req));

            appRouteConfig.Get("/edit/{(?<gameId>\\d+)}", req => new GameController().Edit(req));

            appRouteConfig.Post("/saveChanges/", req => new GameController().SaveChanges(req));

            appRouteConfig.Get("/delete/{(?<gameId>\\d+)}", req => new GameController().Delete(req));

            appRouteConfig.Post("/delete/{(?<gameId>\\d+)}", req => new GameController().DeleteGame(req));

            appRouteConfig.Get("/files/{(?<filename>[\\.\\-\\w]+.(js|css))}",
                req => new ResourcesController().GetFile(req));

            appRouteConfig.Get("/images/{(?<filename>(\\w+\\-*\\w+).(jpeg|jpg|gif|png|bmp|webp))}",
                req => new ResourcesController().GetFile(req));

            appRouteConfig.Get("/cart", req => new ShoppingController().Details(req));

            appRouteConfig.Get("/buy/{(?<gameId>\\d+)}", req => new ShoppingController().AddToCart(req));

            appRouteConfig.Get("/remove/{(?<gameId>\\d+)}", req => new ShoppingController().RemoveFromCart(req));

            appRouteConfig.Post("/finish", req => new ShoppingController().FinishOrder(req));
        }

        private static void ConfigureDatabase()
        {
            var dbContext = new GameStoreDbContext();
            using (dbContext)
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
namespace HTTPServer.GameStoreApp.Controllers
{
    using HTTPServer.GameStoreApp.Data;
    using HTTPServer.GameStoreApp.Infrastructure;
    using HTTPServer.GameStoreApp.Models;
    using HTTPServer.GameStoreApp.Utilities;
    using HTTPServer.Server.Http;
    using HTTPServer.Server.Http.Contracts;
    using HTTPServer.Server.Http.Response;
    using System.IO;
    using System.Linq;

    public class ShoppingController : Controller
    {
        public IHttpResponse Details(IHttpRequest req)
        {
            this.LoginCheck(req);

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (!shoppingCart.Games.Any())
            {
                this.ViewData["formFilled"] = "<h3> No items in your cart</h3>";

                return this.FileViewResponse(@"formFilled");
            }

            string htmlCartRow = File.ReadAllText(string.Format(Config.DefaultPath, "cartRow"));
            string cartContent = "";
            double totalPrice = 0d;

            foreach (var game in shoppingCart.Games)
            {
                string cartRow = htmlCartRow.Replace("{{{gameId}}}", game.Id.ToString());
                cartRow = cartRow.Replace("{{{imageUrl}}}", game.ImageUrl);
                cartRow = cartRow.Replace("{{{title}}}", game.Title);
                cartRow = cartRow.Replace("{{{description}}}", game.Description);
                cartRow = cartRow.Replace("{{{price}}}", game.Price.ToString());
                totalPrice += game.Price;
                cartContent += cartRow;
            }

            string htmlCart = File.ReadAllText(string.Format(Config.DefaultPath, "cart"));

            this.ViewData["cartContent"] = cartContent;
            this.ViewData["totalPrice"] = totalPrice.ToString("f2");

            return this.FileViewResponse(@"cart");
        }

        public IHttpResponse AddToCart(IHttpRequest req)
        {
            //int userId = req.Session.Get<int>(SessionStore.CurrentUserKey);
            int gameId = int.Parse(req.UrlParameters["gameId"]);

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            using (var db = new GameStoreDbContext())
            {
                // User user = db.Users.Find(userId);
                Game game = db.Games.Find(gameId);

                //var userGames = db.UserGames.FirstOrDefault(ug => ug.UserId == userId && ug.GameId == gameId);

                //if (userGames != null)
                //{
                //    this.ViewData["owned"] = "<h3> You allready own this game! </h3>";
                //    return new RedirectResponse(@"/");
                //}

                shoppingCart.Games.Add(game);
            }

            return new RedirectResponse(@"/");
        }

        public IHttpResponse RemoveFromCart(IHttpRequest req)
        {
            int gameId = int.Parse(req.UrlParameters["gameId"]);

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            var gameToRemove = shoppingCart.Games.FirstOrDefault(g => g.Id == gameId);

            if (gameToRemove != null)
            {
                shoppingCart.Games.Remove(gameToRemove);
            }

            return new RedirectResponse(@"/cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);
            int userId = req.Session.Get<int>(SessionStore.CurrentUserKey);

            using (var db = new GameStoreDbContext())
            {
                User user = db.Users.Find(userId);

                foreach (var game in shoppingCart.Games)
                {
                    var userGame = new UserGame(userId, game.Id);

                    db.UserGames.Add(userGame);

                    user.Games.Add(userGame);

                    game.Users.Add(userGame);
                }

                db.SaveChanges();
            }

            return new RedirectResponse(@"/");
        }
    }
}
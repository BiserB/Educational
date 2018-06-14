namespace HTTPServer.GameStoreApp.Controllers
{
    using HTTPServer.GameStoreApp.Data;
    using HTTPServer.GameStoreApp.Infrastructure;
    using HTTPServer.GameStoreApp.Models;
    using HTTPServer.GameStoreApp.Utilities;
    using HTTPServer.Server.Http;
    using HTTPServer.Server.Http.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class HomeController : Controller
    {
        public IHttpResponse Index(IHttpRequest req)
        {
            if (!req.Session.Contains(ShoppingCart.SessionKey))
            {
                req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
            }

            bool loggedIn = this.LoginCheck(req);

            string gameView = "gameUserView";

            using (var db = new GameStoreDbContext())
            {
                if (req.Session.Contains(SessionStore.AdminKey))
                {
                    gameView = "gameAdminView";
                }

                string gameHtml = File.ReadAllText(string.Format(Config.DefaultPath, gameView));
                StringBuilder sb = new StringBuilder();

                List<Game> games = db.Games.ToList();

                int userId = 0;
                List<int> owned = null;

                if (loggedIn)
                {
                    userId = req.Session.Get<int>(SessionStore.CurrentUserKey);

                    owned = db.UserGames.Where(ug => ug.UserId == userId).Select(s => s.GameId).ToList();
                }

                if (req.Path.Contains("owned") && loggedIn)
                {
                    games = db.Games.Where(g => owned.Contains(g.Id)).ToList();
                }

                int open = 0;
                int close = 3;

                for (int i = 0; i < games.Count; i++)
                {
                    var game = games[i];
                    string result = "";
                    if (i == open)
                    {
                        result = "<div class=\"card - group\">";
                        open += 3;
                    }

                    result += gameHtml.Replace("{{{imageUrl}}}", game.ImageUrl);
                    result = result.Replace("{{{title}}}", game.Title);
                    result = result.Replace("{{{price}}}", game.Price.ToString());
                    result = result.Replace("{{{size}}}", game.Size.ToString());
                    result = result.Replace("{{{description}}}", game.Description);
                    result = result.Replace("{{{gameId}}}", game.Id.ToString());
                    if (owned != null && owned.Count > 0 && owned.Contains(game.Id))
                    {
                        result = result.Replace("{{{showBuy}}}", Config.HideElement);
                    }
                    else
                    {
                        result = result.Replace("{{{showBuy}}}", "");
                    }

                    if (i == close || i + 1 == games.Count)
                    {
                        result += "</div>";
                        close += 3;
                    }
                    sb.Append(result);
                }

                string allGames = sb.ToString();

                this.ViewData["allGames"] = allGames;
            }

            return this.FileViewResponse(@"index");
        }
    }
}
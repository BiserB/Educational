namespace HTTPServer.GameStoreApp.Controllers
{
    using HTTPServer.GameStoreApp.Data;
    using HTTPServer.GameStoreApp.Infrastructure;
    using HTTPServer.GameStoreApp.Models;
    using HTTPServer.GameStoreApp.Utilities;
    using HTTPServer.Server.Http;
    using HTTPServer.Server.Http.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class GameController : Controller
    {
        public IHttpResponse GetAddForm(IHttpRequest req)
        {
            this.LoginCheck(req);

            return this.FileViewResponse("addGame");
        }

        public IHttpResponse Add(IHttpRequest req)
        {
            this.LoginCheck(req);

            CultureInfo provider = CultureInfo.InvariantCulture;
            var formData = req.FormData;

            if (formData.Count() < 7)
            {
                WrongFieldError();
                return this.FileViewResponse("/addGame");
            }

            string title = formData["title"];
            string description = formData["description"];
            string imageUrl = formData["imageUrl"];
            double price = double.Parse(formData["price"]);
            double size = double.Parse(formData["size"]);
            string trailerUrl = formData["trailerUrl"];
            DateTime releaseDate = DateTime.ParseExact(formData["releaseDate"], "yyyy-MM-dd", provider);

            if (!ValidFormData(title, trailerUrl, imageUrl, price, size, description))
            {
                WrongFieldError();
                return this.FileViewResponse("/addGame");
            }

            //Game game = new Game("Mass Effect Andromeda", "GameTrailer", "SomeUrl", price: 100.0 , size: 35.0, description: "VeryGoodGame");

            Game game = new Game(title, trailerUrl, imageUrl, price, size, description, releaseDate);

            using (var db = new GameStoreDbContext())
            {
                db.Games.Add(game);
                db.SaveChanges();
            }

            return this.FileViewResponse("/addGame");
        }

        public IHttpResponse ListAllGames(IHttpRequest req)
        {
            this.LoginCheck(req);

            StringBuilder sb = new StringBuilder();

            using (var db = new GameStoreDbContext())
            {
                var games = db.Games.ToList();
                int row = 0;
                string htmlGameRow = File.ReadAllText(string.Format(Config.DefaultPath, "gameRow"));

                foreach (var game in games)
                {
                    string gameId = game.Id.ToString();
                    string title = game.Title;
                    string size = game.Size.ToString();
                    string price = game.Price.ToString();
                    row++;

                    string gameRow = htmlGameRow.Replace("{{{title}}}", title);
                    gameRow = gameRow.Replace("{{{row}}}", row.ToString());
                    gameRow = gameRow.Replace("{{{size}}}", size);
                    gameRow = gameRow.Replace("{{{price}}}", price);
                    gameRow = gameRow.Replace("{{{gameId}}}", gameId);
                    sb.Append(gameRow);
                }
            }

            string result = sb.ToString();

            this.ViewData["gamesList"] = result;

            return this.FileViewResponse("gamesList");
        }

        public IHttpResponse Edit(IHttpRequest req)
        {
            this.LoginCheck(req);

            int gameId = int.Parse(req.UrlParameters["gameId"]);

            using (var db = new GameStoreDbContext())
            {
                Game game = db.Games.Find(gameId);

                string title = game.Title;
                string size = game.Size.ToString();
                string price = game.Price.ToString();
                string videoUrl = game.TrailerUrl;
                string imageUrl = game.ImageUrl;
                string description = game.Description;
                string releaseDate = game.ReleaseDate.ToString();

                string htmlDeleteForm = File.ReadAllText(string.Format(Config.DefaultPath, "edit"));

                string result = htmlDeleteForm.Replace("{{{title}}}", title);
                result = result.Replace("{{{size}}}", size);
                result = result.Replace("{{{price}}}", price);
                result = result.Replace("{{{videoUrl}}}", videoUrl);
                result = result.Replace("{{{imageUrl}}}", imageUrl);
                result = result.Replace("{{{description}}}", description);
                result = result.Replace("{{{releaseDate}}}", releaseDate);
                result = result.Replace("{{{gameId}}}", gameId.ToString());

                this.ViewData["formFilled"] = result;
            }

            return this.FileViewResponse(@"formFilled");
        }

        public IHttpResponse SaveChanges(IHttpRequest req)
        {
            this.LoginCheck(req);

            var formData = req.FormData;
            int gameId = int.Parse(formData["gameId"]);
            CultureInfo provider = CultureInfo.InvariantCulture;

            using (var db = new GameStoreDbContext())
            {
                Game game = db.Games.Find(gameId);

                string title = formData["title"];
                double size = double.Parse(formData["size"]);
                double price = double.Parse(formData["price"]);
                string videoUrl = formData["videoUrl"];
                string imageUrl = formData["imageUrl"];
                string description = formData["description"];
                string relDate = formData["releaseDate"];
                DateTime releaseDate = DateTime.ParseExact(relDate, "yyyy-MM-dd", provider);

                game.Title = title;
                game.Size = size;
                game.Price = price;
                game.ImageUrl = imageUrl;
                game.TrailerUrl = videoUrl;
                game.ReleaseDate = releaseDate;
                game.Description = description;

                db.SaveChanges();
            }

            return ListAllGames(req);
        }

        public IHttpResponse Delete(IHttpRequest req)
        {
            this.LoginCheck(req);

            int gameId = int.Parse(req.UrlParameters["gameId"]);

            using (var db = new GameStoreDbContext())
            {
                Game game = db.Games.Find(gameId);

                string title = game.Title;
                string size = game.Size.ToString();
                string price = game.Price.ToString();
                string videoUrl = game.TrailerUrl;
                string imageUrl = game.ImageUrl;
                string description = game.Description;
                string releaseDate = game.ReleaseDate.ToString();

                string htmlDeleteForm = File.ReadAllText(string.Format(Config.DefaultPath, "delete"));

                string result = htmlDeleteForm.Replace("{{{title}}}", title);
                result = result.Replace("{{{size}}}", size);
                result = result.Replace("{{{price}}}", price);
                result = result.Replace("{{{videoUrl}}}", videoUrl);
                result = result.Replace("{{{imageUrl}}}", imageUrl);
                result = result.Replace("{{{description}}}", description);
                result = result.Replace("{{{releaseDate}}}", releaseDate);

                this.ViewData["formFilled"] = result;
            }

            return this.FileViewResponse(@"formFilled");
        }

        public IHttpResponse DeleteGame(IHttpRequest req)
        {
            int gameId = int.Parse(req.UrlParameters["gameId"]);

            using (var db = new GameStoreDbContext())
            {
                Game game = db.Games.Find(gameId);

                db.Games.Remove(game);

                db.SaveChanges();
            }

            return this.ListAllGames(req);
        }

        public IHttpResponse Info(IHttpRequest req)
        {
            bool loggedIn = this.LoginCheck(req);

            int gameId = int.Parse(req.UrlParameters["gameId"]);

            using (var db = new GameStoreDbContext())
            {
                Game game = db.Games.Find(gameId);

                string title = game.Title;
                string size = game.Size.ToString();
                string price = game.Price.ToString();
                string videoUrl = game.TrailerUrl;
                string imageUrl = game.ImageUrl;
                string description = game.Description;
                string releaseDate = game.ReleaseDate.ToString();

                string infoHtml = "info";

                if (req.Session.Contains(SessionStore.AdminKey))
                {
                    infoHtml = "infoAdmin";
                }

                int userId = 0;
                List<int> owned = null;

                if (loggedIn)
                {
                    userId = req.Session.Get<int>(SessionStore.CurrentUserKey);

                    owned = db.UserGames.Where(ug => ug.UserId == userId).Select(s => s.GameId).ToList();
                }

                string htmlInfo = File.ReadAllText(string.Format(Config.DefaultPath, infoHtml));

                string result = htmlInfo.Replace("{{{title}}}", title);
                result = result.Replace("{{{size}}}", size);
                result = result.Replace("{{{price}}}", price);
                result = result.Replace("{{{videoUrl}}}", videoUrl);
                result = result.Replace("{{{imageUrl}}}", imageUrl);
                result = result.Replace("{{{description}}}", description);
                result = result.Replace("{{{releaseDate}}}", releaseDate);
                result = result.Replace("{{{gameId}}}", gameId.ToString());
                if (owned != null && owned.Count > 0 && owned.Contains(game.Id))
                {
                    result = result.Replace("{{{showBuy}}}", Config.HideElement);
                }

                this.ViewData["formFilled"] = result;
            }

            return this.FileViewResponse(@"formFilled");
        }

        private bool ValidFormData(string title, string trailerUrl, string imageUrl, double price, double size, string description)
        {
            bool validTitle = 2 < title.Length || title.Length > 100;
            bool validTrailer = trailerUrl.Length == 11;
            bool validImage = imageUrl == null || imageUrl.StartsWith("http://") || imageUrl.StartsWith("https://");
            bool validPrice = price > 0;
            bool validSize = size > 0;
            bool validDescription = description.Length > 20;

            if (validTitle && validTrailer && validImage && validPrice && validSize && validDescription)
            {
                return true;
            }
            return false;
        }

        private void WrongFieldError()
        {
            this.ViewData["error"] = "You have wrong fields";
            this.ViewData["showError"] = "block";
        }
    }
}
namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using Data;
    using Infrastructure;
    using Models;
    using Server.Http.Contracts;
    using System.Linq;

    public class CakesController : Controller
    {
        public IHttpResponse Add()
        {
            this.ViewData["showResult"] = "none";

            return this.FileViewResponse(@"cakes\add");
        }

        public IHttpResponse Add(IHttpRequest req)
        {
            var formData = req.FormData;

            var name = formData["name"];
            var price = formData["price"];
            var imageUrl = formData["imageUrl"];

            var cake = new Product
            {
                Name = name,
                Price = decimal.Parse(price),
                ImageUrl = imageUrl
            };

            using (var db = new ByTheCakeDbContext())
            {
                db.Products.Add(cake);
                db.SaveChanges();
            }

            this.ViewData["name"] = name;
            this.ViewData["price"] = price;
            this.ViewData["image"] = imageUrl;
            this.ViewData["showResult"] = "block";

            return this.FileViewResponse(@"cakes\add");
        }

        public IHttpResponse Search(IHttpRequest req)
        {
            const string searchTermKey = "searchTerm";

            var urlParameters = req.UrlParameters;

            this.ViewData["results"] = "";
            this.ViewData["searchTerm"] = "";

            if (urlParameters.ContainsKey(searchTermKey))
            {
                var searchTerm = urlParameters[searchTermKey];

                this.ViewData["searchTerm"] = searchTerm;

                var results = "";

                using (var db = new ByTheCakeDbContext())
                {
                    var foundCakes = db.Products
                                .Where(p => p.Name.ToLower().Contains(searchTerm))
                                .ToList();

                    if (foundCakes.Any())
                    {
                        foreach (var cake in foundCakes)
                        {
                            string line = $"<div><a href=\"/details/{cake.Id}\">{cake.Name}</a> ${cake.Price} " +
                                $"<a href=\"/shopping/add/{cake.Id}?searchTerm={searchTerm}\"> Order</a></div>";

                            results += line;
                        }
                    }
                    else
                    {
                        results = "No cakes found";
                    }

                    this.ViewData["results"] = results.TrimEnd();
                }
            }
            else
            {
                this.ViewData["results"] = "Please, enter search term";
            }

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (shoppingCart.Orders.Any())
            {
                var totalProducts = shoppingCart.Orders.Count;
                var totalProductsText = totalProducts != 1 ? "products" : "product";

                this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
            }
            else
            {
                this.ViewData["showCart"] = "none";
            }

            return this.FileViewResponse(@"cakes\search");
        }

        public IHttpResponse Details(IHttpRequest req)
        {
            int id = int.Parse(req.UrlParameters["id"]);

            using (var db = new ByTheCakeDbContext())
            {
                var cake = db.Products.Find(id);

                this.ViewData["name"] = cake.Name;
                this.ViewData["price"] = cake.Price.ToString("F2");
                this.ViewData["image"] = cake.ImageUrl.ToString();
            }

            return this.FileViewResponse(@"cakes\details");
        }
    }
}
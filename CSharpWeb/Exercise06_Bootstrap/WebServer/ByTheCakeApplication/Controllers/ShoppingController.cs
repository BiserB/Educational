namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using Data;
    using HTTPServer.Server.Http;
    using Infrastructure;
    using Models;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using System.Linq;

    public class ShoppingController : Controller
    {
        public IHttpResponse AddToCart(IHttpRequest req)
        {
            string redirectUrl = "/search";
            string searchTermKey = "searchTerm";

            int id = int.Parse(req.UrlParameters["id"]);

            using (var db = new ByTheCakeDbContext())
            {
                var cake = db.Products.Find(id);

                if (cake == null)
                {
                    return new NotFoundResponse();
                }

                var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

                shoppingCart.Orders.Add(cake);

                if (req.UrlParameters.ContainsKey(searchTermKey))
                {
                    redirectUrl = $"{redirectUrl}?{searchTermKey}={req.UrlParameters[searchTermKey]}";
                }
            }

            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse ShowCart(IHttpRequest req)
        {
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (!shoppingCart.Orders.Any())
            {
                this.ViewData["cartItems"] = "No items in your cart";
                this.ViewData["totalCost"] = "0.00";
            }
            else
            {
                var items = shoppingCart
                    .Orders
                    .Select(i => $"<div><a href=\"/details/{i.Id}\">{i.Name}</a> - ${i.Price:F2}</div><br />");

                var totalPrice = shoppingCart
                    .Orders
                    .Sum(i => i.Price);

                this.ViewData["cartItems"] = string.Join(string.Empty, items);
                this.ViewData["totalCost"] = $"{totalPrice:F2}";
            }

            return this.FileViewResponse(@"shopping\cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            var session = req.Session;

            var userId = session.Get<int>(SessionStore.CurrentUserKey);

            var products = session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders;

            var productIds = products.Select(p => p.Id).ToList();

            using (var db = new ByTheCakeDbContext())
            {
                var order = new Order(userId);
                db.Orders.Add(order);
                db.SaveChanges();

                foreach (var product in products)
                {
                    int prodId = product.Id;
                    int productQty = productIds.Count(id => id == prodId);

                    if (productQty > 0)
                    {
                        productIds.RemoveAll(id => id == prodId);

                        var productOrder = new ProductOrder(product.Id, order.Id, productQty);

                        db.ProductOrders.Add(productOrder);
                    }
                    if (productIds.Count == 0)
                    {
                        break;
                    }
                }

                db.SaveChanges();
            }

            req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders.Clear();

            return this.FileViewResponse(@"shopping\finish-order");
        }

        public IHttpResponse UserOrders(IHttpRequest req)
        {
            int userId = req.Session.Get<int>(SessionStore.CurrentUserKey);

            string result = "";

            using (var db = new ByTheCakeDbContext())
            {
                var orders = db.Orders.Where(o => o.UserId == userId).ToList();

                for (int i = 0; i < orders.Count; i++)
                {
                    var orderId = orders[i].Id;
                    var orderDate = orders[i].OrderDate;

                    var productsPrices = db.ProductOrders
                        .Where(po => po.OrderId == orderId)
                        .Select(po => new
                        {
                            Price = (po.Product.Price) * (po.ProductQty)
                        })
                        .ToList();

                    var totalPrice = productsPrices.Sum(p => p.Price);

                    result += $"<tr><td><a href=\"/orders/{orderId}\">{orderId}</a></td>" +
                                  $"<td>{orderDate}</td>" +
                                  $"<td>${totalPrice}</td></tr>";
                }
            }

            this.ViewData["orders"] = result;

            return this.FileViewResponse(@"shopping\my-orders");
        }

        public IHttpResponse OrderDetails(IHttpRequest req)
        {
            int orderId = int.Parse(req.UrlParameters["id"]);

            string tableContent = "";
            string date = "";

            using (var db = new ByTheCakeDbContext())
            {
                var orderDate = db.Orders
                     .Where(o => o.Id == orderId)
                     .Select(o => o.OrderDate)
                     .First()
                     .ToString("dd-MM-yyyy");

                var productList = db.ProductOrders
                    .Where(po => po.OrderId == orderId)
                    .Select(po => new
                    {
                        po.ProductId,
                        po.Product.Name,
                        po.Product.Price,
                        po.ProductQty
                    })
                    .ToList();

                foreach (var product in productList)
                {
                    tableContent += $"<tr><td><a href=\"/details/{product.ProductId}\"> {product.Name} </a></td>" +
                        $"<td> {product.Price} </td>" +
                        $"<td> {product.ProductQty}</td></tr>";
                }

                date = $"<p></p><p><em>Created on {orderDate}</em></p>";
            }

            this.ViewData["table"] = tableContent;
            this.ViewData["date"] = date;

            return this.FileViewResponse(@"shopping\order-details");
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SimpleMVC.ByTheCakeApp.Data;
using SimpleMVC.ByTheCakeApp.Models;
using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.ByTheCakeApp.Views;
using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Enums;
using SimpleMVC.Server.HTTP.Response;

namespace SimpleMVC.ByTheCakeApp.Controllers
{
    public class ShoppingCartController
    {
        public IHttpResponse AddProduct(IHttpRequest request)
        {
            string sessionId = request.Session.Id;

            ShoppingCart cart = ShoppingCartStorage.GetOrAddCart(sessionId);

            Dictionary<string, string> formData = request.FormData;

            string cakeName = formData["cakename"];
            double cakePrice = double.Parse(formData["cakeprice"]);
            string previous = formData["previoussearch"];

            var list = cart.Items;
            if (!list.ContainsKey(cakeName))
            {
                list[cakeName] = new CakeDetails(cakePrice);
            }
            else
            {
                list[cakeName].AddPiece();
            }            

            return new ViewResponse(HttpStatusCode.OK, new FoundCakeView(previous, sessionId));
        }

        public IHttpResponse CartReview(IHttpRequest request)
        {
            string sessionId = request.Session.Id;

            ShoppingCart cart = ShoppingCartStorage.GetOrAddCart(sessionId);

            return new ViewResponse(HttpStatusCode.OK, new CartView(cart.Items));
        }

        public IHttpResponse FinishOrder(IHttpRequest request)
        {
            string sessionId = request.Session.Id;

            ShoppingCartStorage.DeleteCart(sessionId);

            return new ViewResponse(HttpStatusCode.OK, new FinishOrderView());
        }
    }
}

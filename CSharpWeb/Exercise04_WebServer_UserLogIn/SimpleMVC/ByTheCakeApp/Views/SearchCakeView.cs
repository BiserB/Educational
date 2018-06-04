using SimpleMVC.ByTheCakeApp.Data;
using SimpleMVC.ByTheCakeApp.Models;
using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using System.IO;

namespace SimpleMVC.ByTheCakeApp.Views
{
    public class SearchCakeView : IView
    {
        private readonly ShoppingCart cart;

        public SearchCakeView(string sessionId)
        {
            this.cart = ShoppingCartStorage.GetOrAddCart(sessionId);
        }

        public string View()
        {
            int cartItems = 0;
            var items = cart.Items;

            foreach (var item in items)
            {
                cartItems += item.Value.Qty;
            }

            string cartInfo = $"<p id=\"cart\"><a href=\"/cart\">Shopping Cart products:</a> {cartItems} </p>";                            

            string fullPath = Paths.basePath + Paths.resourcePath + "searchcake.html"; 

            string searchcake = File.ReadAllText(fullPath);            

            return searchcake.Replace("<cart-info>", cartInfo); 
        }
    }
}

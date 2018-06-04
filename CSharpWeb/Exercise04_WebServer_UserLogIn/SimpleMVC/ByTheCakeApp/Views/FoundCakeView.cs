using SimpleMVC.ByTheCakeApp.Data;
using SimpleMVC.ByTheCakeApp.Models;
using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using System;
using System.IO;
using System.Linq;

namespace SimpleMVC.ByTheCakeApp.Views
{
    class FoundCakeView : IView
    {
        private readonly string name;
        private string[] cakes;
        private bool found;
        private ShoppingCart cart;        

        public FoundCakeView(string name, string sessionId )
        {
            this.found = false;
            this.name = name;
            this.cakes = GetMatches();            
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

            string cartInfo = $"<p id=\"cart\"><a href=\"/cart\">Shopping Cart products:</a> {cartItems} </p>" +
                            $"<h4>Search results:</h4>";
            
            string fullPath = Paths.basePath + Paths.resourcePath + "searchresult.html";

            string searchcake = File.ReadAllText(fullPath);

            string result = "";
            if (found)
            {
                for (int i = 0; i < cakes.Length; i++)
                {
                    string[] cakeData = cakes[i].Split(',');                    
                    string cakeName = cakeData[0];
                    string cakePrice = "$" + cakeData[1];

                    string cake = "<form id=\"orderform\" method=\"post\" action=\"/order\">";
                    cake += $"{cakeName} {cakePrice}";
                    cake += $"<input type=\"hidden\" name=\"cakename\" value=\"{cakeName}\"/>";
                    cake += $"<input type=\"hidden\" name=\"cakeprice\" value=\"{cakeData[1]}\"/>";
                    cake += $"<input type=\"hidden\" name=\"previoussearch\" value=\"{name}\"/>";
                    cake += "<input id=\"submit\" type=\"submit\" value=\"Order\"></form>";
                    result += $"<span>{cake}</span><p></p>";
                }                
            }
            else
            {
                result = $"{name} not found";
            }

            string s = searchcake.Replace("<cart-info>", cartInfo);
            return s.Replace("<res-1>", result);
        }

        private string[] GetMatches()
        {
            string[] data = File.ReadAllLines(Paths.basePath + Paths.dataPath + Paths.dataFilename);

            string[] cakes = data.Where(c => c.Contains(this.name)).ToArray();
           
            if (cakes.Length > 0)
            {
                found = true;
            }

            return cakes;
        }
    }
}

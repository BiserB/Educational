using SimpleMVC.ByTheCakeApp.Models;
using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleMVC.ByTheCakeApp.Views
{
    public class CartView : IView
    {
        private IDictionary<string, CakeDetails> cakes;

        public CartView(IDictionary<string, CakeDetails> cakes)
        {
            this.cakes = cakes;
        }

        public string View()
        {  
            StringBuilder itemsList = new StringBuilder();
            double totalPrice = 0;

            foreach (var cake in cakes)
            {
                double cakePrice = cake.Value.Price;
                int cakeCount = cake.Value.Qty;
                totalPrice += cakePrice * cakeCount;

                itemsList.AppendLine($"<p>{cake.Key} - ${cakePrice} count: {cakeCount}<p>");                
            }
            itemsList.AppendLine( $"<hr/> Total Cost: ${totalPrice} <hr/>");

            string fullPath = Paths.basePath + Paths.resourcePath + "cart.html";

            string cartHtml = File.ReadAllText(fullPath);

            return cartHtml.Replace("<items-list>", itemsList.ToString());
        }
    }
}

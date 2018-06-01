using SimpleMVC.ByTheCakeApp.Models;
using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.ByTheCakeApp.Views;
using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Enums;
using SimpleMVC.Server.HTTP.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimpleMVC.ByTheCakeApp.Controllers
{
    public class CakeController
    {
        public IHttpResponse AddCakeForm()
        {
            return new ViewResponse(HttpStatusCode.OK, new AddCakeView());
        }

        public IHttpResponse RegisterCake(string name, string priceString)
        {
            double price = 0;
            var priceIsCorrect = double.TryParse(priceString, out price);
            if (!priceIsCorrect)
            {
                return new ViewResponse(HttpStatusCode.OK, new AddCakeView());
            }

            Cake newCake = new Cake(name, price);

            var writer = new StreamWriter(Paths.basePath + Paths.dataPath + "database.csv", true);

            using (writer)
            {
                writer.WriteLine($"{name},{price}");
            }

            return new ViewResponse(HttpStatusCode.OK, new AddedCakeView(name, priceString));
        }

        internal IHttpResponse SearchCakeForm(Dictionary<string, string> urlParameters)
        {
            
            if (!urlParameters.Any())
            {
                return new ViewResponse(HttpStatusCode.OK, new SearchCakeView());
            }
            string name = urlParameters["name"];
        
            string[] data = File.ReadAllLines(Paths.basePath + Paths.dataPath + "database.csv");

            string[] cakes = data.Where(c => c.Contains(name)).ToArray();

            bool found = false;            

            if (cakes.Length > 0)
            {
                found = true;                 
            }

            return new ViewResponse(HttpStatusCode.OK, new FoundCakeView(name, cakes, found));
        }
    }
}

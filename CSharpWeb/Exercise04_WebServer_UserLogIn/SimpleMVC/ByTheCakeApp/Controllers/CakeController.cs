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

            var writer = new StreamWriter(Paths.basePath + Paths.dataPath + Paths.dataFilename, true);

            using (writer)
            {
                writer.WriteLine($"{name},{price}");
            }

            return new ViewResponse(HttpStatusCode.OK, new AddedCakeView(name, priceString));
        }

        public IHttpResponse SearchCakeForm(IHttpRequest request)
        {
            var urlParameters = request.UrlParameters;

            string sessionId = request.Session.Id;

            if (!urlParameters.Any())
            {
                return new ViewResponse(HttpStatusCode.OK, new SearchCakeView(sessionId));
            }

            string name = urlParameters["name"];  

            return new ViewResponse(HttpStatusCode.OK, new FoundCakeView(name, sessionId));
        }
    }
}

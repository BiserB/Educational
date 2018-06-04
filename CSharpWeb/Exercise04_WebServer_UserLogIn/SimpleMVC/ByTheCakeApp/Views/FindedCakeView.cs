using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using System;
using System.IO;

namespace SimpleMVC.ByTheCakeApp.Views
{
    class FoundCakeView : IView
    {
        private string name;
        private string[] cakes;
        private bool found;

        public FoundCakeView(string name, string[] cakes, bool found)
        {
            this.name = name;
            this.cakes = cakes;
            this.found = found;
        }

        public string View()
        {
            string result = "";
            
            string fullPath = Paths.basePath + Paths.resourcePath + "searchcake.html";

            string searchcake = File.ReadAllText(fullPath);

            if (found)
            {
                foreach (var line in cakes)
                {
                    string cake = line.Replace(",", "- $");
                    result += $"<p>{cake}</p>";
                }                
            }
            else
            {
                result = $"{name} not found";
            }

            return searchcake.Replace("<res-1>", result);
        }
    }
}

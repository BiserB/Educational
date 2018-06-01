using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using System.IO;


namespace SimpleMVC.ByTheCakeApp.Views
{
    public class AddedCakeView: IView
    {
        private readonly string name;
        private readonly string price;

        public AddedCakeView(string name, string price)
        {
            this.name = name;
            this.price = price;
        }

        public string View()
        {
            string fullPath = Paths.basePath + Paths.resourcePath + "addcake.html";

            string addcake = File.ReadAllText(fullPath);

            string nameAdded = addcake.Replace("<el-1>", $"<p>Name: {name}</p>");
            string priceNameAdded = nameAdded.Replace("<el-2>", $"<p>Price: {price}</p>");

            return priceNameAdded;
        }
    }
}

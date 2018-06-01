using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using System.IO;


namespace SimpleMVC.ByTheCakeApp.Views
{
    public class HomeView : IView
    {
        public string View()
        {
            string fullPath = Paths.basePath + Paths.resourcePath + "index.html";

            string index = File.ReadAllText(fullPath);

            return index;
        }

    }
}

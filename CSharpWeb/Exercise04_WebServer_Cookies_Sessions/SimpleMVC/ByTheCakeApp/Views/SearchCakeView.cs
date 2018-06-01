using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using System.IO;

namespace SimpleMVC.ByTheCakeApp.Views
{
    public class SearchCakeView : IView
    {
        public string View()
        {
            string fullPath = Paths.basePath + Paths.resourcePath + "searchcake.html"; 

            string searchcake = File.ReadAllText(fullPath);

            return searchcake;
        }
    }
}

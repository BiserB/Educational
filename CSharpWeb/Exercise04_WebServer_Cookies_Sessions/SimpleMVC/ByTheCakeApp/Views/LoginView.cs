using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using System.IO;

namespace SimpleMVC.ByTheCakeApp.Views
{
    public class LoginView : IView
    {     
        public string View()
        {
            string fullPath = Paths.basePath + Paths.resourcePath + "login.html";

            string login = File.ReadAllText(fullPath);

            return login;
        }
    }
}

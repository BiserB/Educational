using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using System;
using System.IO;


namespace SimpleMVC.ByTheCakeApp.Views
{
    public class AddCakeView : IView
    {
        public string View()
        {            
            string fullPath = Paths.basePath + Paths.resourcePath + "addcake.html";

            string addcake = File.ReadAllText(fullPath);

            return addcake;
        }
    }
}

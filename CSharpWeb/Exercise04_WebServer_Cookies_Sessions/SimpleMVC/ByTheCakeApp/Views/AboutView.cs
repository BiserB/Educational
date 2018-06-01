using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using System;
using System.IO;

namespace SimpleMVC.ByTheCakeApp.Views
{
    public class AboutView : IView
    {
        public string View()
        {            
            string fullPath = Paths.basePath + Paths.resourcePath + "about.html";

            string about = File.ReadAllText(fullPath);

            return about;
        }
    }
}

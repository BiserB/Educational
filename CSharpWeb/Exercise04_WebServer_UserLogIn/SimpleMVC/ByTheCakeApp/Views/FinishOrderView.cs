using SimpleMVC.ByTheCakeApp.Utilities;
using SimpleMVC.Server.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleMVC.ByTheCakeApp.Views
{
    public class FinishOrderView : IView
    {
        public string View()
        {
            string fullPath = Paths.basePath + Paths.resourcePath + "finish.html";

            string finishHtml = File.ReadAllText(fullPath);

            return finishHtml;
        }
    }
}

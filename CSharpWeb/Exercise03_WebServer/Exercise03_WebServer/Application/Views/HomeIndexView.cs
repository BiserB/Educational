using Exercise03_WebServer.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Application.Views
{
    public class HomeIndexView : IView
    {     
        public string View()
        {
            return "<body><h1>Welcome!</h1></body>";
        }
    }
}

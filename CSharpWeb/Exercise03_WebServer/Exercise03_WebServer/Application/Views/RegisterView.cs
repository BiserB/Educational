using Exercise03_WebServer.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Application.Views
{
    public class RegisterView : IView
    {
        public string View()
        {
            return "<body><form method=\"POST\"> " +
                "Name</br>" +
                "<input type=\"text\" name=\"name\"/></br>" +
                "<input type=\"submit\"/>" +
                "</form></body>";
        }
    }
}

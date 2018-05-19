using Exercise03_WebServer.Application.Views;
using Exercise03_WebServer.Server.Enums;
using Exercise03_WebServer.Server.HTTP.Contracts;
using Exercise03_WebServer.Server.HTTP.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03_WebServer.Application.Controllers
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            var response =  new ViewResponse(HttpStatusCode.OK, new HomeIndexView());

            return response;
        }
    }
}

using SimpleMVC.Application;
using SimpleMVC.ByTheCakeApp;
using SimpleMVC.Server;
using SimpleMVC.Server.Contracts;
using SimpleMVC.Server.Routing;
using System;

namespace SimpleMVC
{
    public class Launcher
    {
        private static void Main()
        {
            int Port = 8888;

            IAppRouteConfig routeConfig = new AppRouteConfig();

            var app = new MainApplication();

            //var app = new ByTheCakeApplication();

            app.Configure(routeConfig);

            WebServer webServer = new WebServer(Port, routeConfig);

            webServer.Run();

            Console.ReadLine();
        }
    }
}
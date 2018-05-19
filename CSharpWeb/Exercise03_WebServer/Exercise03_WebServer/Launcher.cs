using Exercise03_WebServer.Application;
using Exercise03_WebServer.Server;
using Exercise03_WebServer.Server.Contracts;
using Exercise03_WebServer.Server.Routing;
using Exercise03_WebServer.Server.Routing.Contracts;
using System;

namespace Exercise03_WebServer
{
    public class Launcher : IRunable
    {        
        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            IApplication app = new MainApplication();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Start(routeConfig);

            WebServer webServer = new WebServer(1337, routeConfig);
            webServer.Run();
        }
    }
}

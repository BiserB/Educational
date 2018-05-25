using SimpleWebServer.Application;
using SimpleWebServer.Server;
using SimpleWebServer.Server.Contracts;
using SimpleWebServer.Server.Routing;
using SimpleWebServer.Server.Routing.Contracts;

namespace SimpleWebServer
{
    public class Launcher
    {
        
        public static void Main()
        {
            int Port = 1337;

            IAppRouteConfig routeConfig = new AppRouteConfig();

            IApplication app = new MainApplication();

            app.Configure(routeConfig);

            WebServer webServer = new WebServer(Port, routeConfig);
            webServer.Run();
        }        
    }
}
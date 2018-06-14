using HTTPServer.ByTheCakeApplication;
using HTTPServer.Server;
using HTTPServer.Server.Routing;

namespace HTTPServer
{
    internal class Launcher
    {
        private static void Main(string[] args)
        {
            Run(args);
        }

        private static void Run(string[] args)
        {
            //TODO: Initialize application
            var application = new ByTheCakeApp();

            var appRouteConfig = new AppRouteConfig();
            //TODO: Configure App Route Configuration
            application.Configure(appRouteConfig);

            var server = new WebServer(55000, appRouteConfig);

            server.Run();
        }
    }
}
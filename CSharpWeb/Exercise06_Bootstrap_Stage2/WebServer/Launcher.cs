namespace HTTPServer
{
    using HTTPServer.GameStoreApp;
    using HTTPServer.Server;
    using HTTPServer.Server.Routing;

    public class Launcher
    {
        private static void Main(string[] args)
        {
            Run(args);
        }

        private static void Run(string[] args)
        {
            var application = new GameStoreApplication();

            var appRouteConfig = new AppRouteConfig();

            application.Configure(appRouteConfig);

            var server = new WebServer(55000, appRouteConfig);

            server.Run();
        }
    }
}
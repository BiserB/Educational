
namespace KittenWeb.App
{
    using KittenWeb.Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        public static void Main()
        {
            int port = 55000;

            var controllerRouter = new ControllerRouter();

            var resourceRouter = new ResourceRouter();

            var webServer = new WebServer(port, controllerRouter, resourceRouter);

            var dbContext = new KittenWebDbContext();

            MvcEngine.Run(webServer, dbContext);
        }
    }
}

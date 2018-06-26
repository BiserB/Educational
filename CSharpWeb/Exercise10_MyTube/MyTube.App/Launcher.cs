namespace MyTube.App
{
    using MyTube.Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        public static void Main()
        {
            int port = 55000;

            WebServer server = new WebServer(port, new ControllerRouter(), new ResourceRouter());

            MvcEngine.Run(server, new MyTubeDbContext());
        }
    }
}
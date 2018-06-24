
namespace FDMC.App
{
    using WebServer;
    using FDMC.Data;
    using Microsoft.EntityFrameworkCore;
    using SimpleMVC.Framework.Routers;
    using SimpleMVC.Framework;

    public class Launcher
    {
        public static void Main()
        {
            using (var db = new FDMCDbContext())
            {
                db.Database.Migrate();
            }

            int port = 55000;

            WebServer server = new WebServer(
                                    port,
                                    new ControllerRouter(),
                                    new ResourceRouter()
                                    );

            MvcEngine.Run(server);
        }
    }
}

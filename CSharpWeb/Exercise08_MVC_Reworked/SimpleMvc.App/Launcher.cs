namespace SimpleMvc.App
{
    using Microsoft.EntityFrameworkCore;
    using SimpleMVC.Data;
    using SimpleMVC.Framework;
    using SimpleMVC.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        public static void Main()
        {
            using (var dbContext = new SimpleMVCDbContext())
            {                
                dbContext.Database.Migrate();
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
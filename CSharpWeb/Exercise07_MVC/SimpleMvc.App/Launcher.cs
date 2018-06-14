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

            WebServer server = new WebServer(55000, new ControllerRouter());

            MvcEngine.Run(server);
        }
    }
}
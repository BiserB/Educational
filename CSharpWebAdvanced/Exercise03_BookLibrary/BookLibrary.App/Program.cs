using BookLibrary.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookLibrary.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var dbContext = new BookLibraryDbContext())
            {
                dbContext.Database.Migrate();
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(options => { options.Listen(IPAddress.Loopback, 9999); })
                .UseStartup<Startup>();
    }
}
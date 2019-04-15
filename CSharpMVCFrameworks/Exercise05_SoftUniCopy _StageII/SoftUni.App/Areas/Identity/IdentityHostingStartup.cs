using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SoftUni.App.Areas.Identity.IdentityHostingStartup))]

namespace SoftUni.App.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
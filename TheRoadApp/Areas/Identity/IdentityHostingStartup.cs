using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TheRoadApp.Areas.Identity.IdentityHostingStartup))]
namespace TheRoadApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
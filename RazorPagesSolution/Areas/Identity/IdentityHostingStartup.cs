using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesSolution.Areas.Identity.Data;

[assembly: HostingStartup(typeof(RazorPagesSolution.Areas.Identity.IdentityHostingStartup))]
namespace RazorPagesSolution.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RazorPagesSolutionIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("RazorPagesSolutionIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<RazorPagesSolutionIdentityDbContext>();
            });
        }
    }
}
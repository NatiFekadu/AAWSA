using System;
using AAWSA.Areas.Identity.Data;
using AAWSA.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AAWSA.Areas.Identity.IdentityHostingStartup))]
namespace AAWSA.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AAWSADbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AAWSADbContextConnection")));


                /*  services.AddDefaultIdentity<AAWSAUser>(options => options.SignIn.RequireConfirmedAccount = false)
                   .AddEntityFrameworkStores<AAWSADbContext>(); */
                services.AddIdentity<AAWSAUser, IdentityRole>()
                  .AddEntityFrameworkStores<AAWSADbContext>()
                  .AddDefaultUI().AddTokenProvider<DataProtectorTokenProvider<AAWSAUser>>(TokenOptions.DefaultProvider); ;
            });
        }
    }
}
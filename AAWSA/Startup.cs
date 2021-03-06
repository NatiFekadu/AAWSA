using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AAWSA.Models;
using Microsoft.AspNetCore.Mvc;
using AAWSA.Data;
using Microsoft.AspNetCore.Identity;
using AAWSA.Areas.Identity.Data;

namespace AAWSA
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();
            services.AddDbContext<ComplaintDbContext>
            (item => item.UseSqlServer(Configuration.GetConnectionString("AAWSADbContextConnection")));
            services.AddSession();


          //  services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AAWSADbContext>();

          
          /* services.AddMvc().AddRazorPagesOptions(options => {
                options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);*/



            


            // services.AddIdentity<AAWSAUser, IdentityRole>()
            //      .AddEntityFrameworkStores<AAWSADbContext>()
            //      .AddDefaultUI();

            //services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AAWSADbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

          /*   app.UseEndpoints(endpoints =>
              {
                  endpoints.MapControllerRoute(
                      name: "default",
                      pattern: "{controller=Home}/{action=Index}/{id?}");
                  endpoints.MapRazorPages();
              });
          */
            
            
              app.UseEndpoints(endpoints =>
              {
                  endpoints.MapAreaControllerRoute(
                     name: "myIdentity",
                     areaName: "Identity",
                     pattern: "Identity/{controller=Home}/{action=Index}/{id?}");

                  

                  endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");


                  endpoints.MapControllerRoute(
                      name: "registration",
                      pattern:"Views /{ controller = Admin}/{ action = Index}/{ id ?}");


                    endpoints.MapRazorPages();

              }); 
            
        }
    }
}

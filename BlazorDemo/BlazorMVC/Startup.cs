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
using Microsoft.Extensions.Logging;
using BlazorMVC.Data;

namespace BlazorMVC
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
            //Register SQL Server to EF Core Services
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("MyDemoDbConnectionString")
                    //If DB name doesn't exist in connstr, it will create a new DB
                    );
            });

            //Register Logging Services
            services.AddLogging(options =>
            {
                options.ClearProviders();
                options.AddConsole();
            });
            //ILogger step 1
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
            //ILogger step 2
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                logger.LogInformation("APP is Running in Start Up Mode");
                //ILogger step 3
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseMvc(); Approach 1) Alternative to MVC API Controller, but not best
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                //For API Controller
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=index}/{id?}"
                    );

                //Used all the Attribute defined routes in the Controller
                endpoints.MapControllers();

                endpoints.MapRazorPages();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller}/{action=index}/{id?}");
                //Approach 2) Alternative to MVC API Controller, Better choice
            });
        }
    }
}

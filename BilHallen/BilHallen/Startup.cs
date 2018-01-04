using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BilHallen.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BilHallen
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorRights", policy => policy.RequireClaim("CarsAppRole", "Administrator"));
                options.AddPolicy("AnonymousRights", policy => policy.RequireClaim("CarsAppRole", "Anonymous"));
                options.AddPolicy("ViewRights", policy => policy.RequireAssertion(context =>
                {
                    var user = context.User;
                    var adminRights = user.Claims.Where(a => a.Type == "CarsAppRole").Select(a => a.Value).FirstOrDefault();

                    if (adminRights == "Administrator")
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }));
            });
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseDirectoryBrowser();
            app.UseStatusCodePages();
            app.UseMvc();
            
        }
    }
}

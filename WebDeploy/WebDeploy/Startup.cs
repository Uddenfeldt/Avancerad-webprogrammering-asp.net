using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebDeploy.Models;

namespace WebDeploy
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

            services.AddMvc();

            // Konfigurering som krävs för att hantera egna appsettingsvärden (med hård typad härlig modell)
            services.AddSingleton(Configuration.GetSection("MailConfiguration").Get<MailConfiguration>());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MailConfiguration mail)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();
            app.UseDirectoryBrowser();
            app.UseStatusCodePages();
            app.UseMvc();

        }
    }
}
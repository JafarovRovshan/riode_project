using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Riode_WebUI.Models.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode_WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<RiodeDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("cString"));
            });

            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}

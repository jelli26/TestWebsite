using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TestWebsite
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //Add services for connecting to MySQL database tables
            services.Add(new ServiceDescriptor(typeof(Models.VideoGameListContext), new Models.VideoGameListContext(Configuration.GetConnectionString("GameConnection"))));
            services.Add(new ServiceDescriptor(typeof(Models.AmiiboListContext), new Models.AmiiboListContext(Configuration.GetConnectionString("AmiiboConnection"))));
            services.Add(new ServiceDescriptor(typeof(Models.GuestContext), new Models.GuestContext(Configuration.GetConnectionString("GuestbookConnection"))));
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseBrowserLink();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}

            //app.UseStaticFiles();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");

            //routes.MapRoute(
            //    name: "WebAppsHelpDocs",
            //        template: "{controller=WebAppsHelpDocs}/{action=Index}/{id?}");
            //});

            //Redirect any non-API calls to the Angular application
            //so our application can handle the routing
            app.Use(async (context, next) => {
                await next();
                if (context.Response.StatusCode == 404 &&
                   !Path.HasExtension(context.Request.Path.Value) &&
                   !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            //Configures application for usage as API
            //with default route of '/api/[Controller]'
            app.UseMvcWithDefaultRoute();

            //Configures application to serve the index.html file from /wwwroot
            //when you access the server from a web browser
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}

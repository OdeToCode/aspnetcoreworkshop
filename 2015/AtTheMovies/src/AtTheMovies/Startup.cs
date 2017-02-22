using System;
using System.Threading.Tasks;
using AtTheMovies.Middleware;
using AtTheMovies.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AtTheMovies
{
    public class Startup
    {
        public IConfiguration Configuration { get; protected set; }

        public Startup(ILoggerFactory loggerFactory, 
                       IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
           
            loggerFactory.AddConsole();
        }
      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddSingleton<IGreeter, Greeter>();
        }

        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error/index");
            }

           
            app.UseStaticFiles();

            var options = new GreeterOptions
            {
                Path = "/greeter",
                Message = "A custom greeting message"
            };
            app.UseGreeter(options);

            app.UseMvcWithDefaultRoute();

            app.Use(next =>
            {
                return context =>
                {
                    if (context.Request.Path.StartsWithSegments("/oops"))
                    {
                        throw new InvalidOperationException("oops!");
                    }
                    return next(context);
                };
            });

            app.Run(async (context) =>
            {               
                await context.Response.WriteAsync(greeter.FetchGreeting());
            });            
        }
    }
}

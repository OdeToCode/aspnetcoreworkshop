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

            app.UseStaticFiles();
            
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {               
                await context.Response.WriteAsync(greeter.FetchGreeting());
            });            
        }
    }
}

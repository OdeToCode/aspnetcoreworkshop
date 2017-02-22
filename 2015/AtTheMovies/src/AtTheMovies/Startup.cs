using System;
using System.Threading.Tasks;
using AtTheMovies.Data;
using AtTheMovies.Middleware;
using AtTheMovies.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GreeterOptions = AtTheMovies.Services.GreeterOptions;
using Microsoft.EntityFrameworkCore;

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
            services.AddOptions();
            services.Configure<GreeterOptions>(
                Configuration.GetSection("Greeter"));
            services.AddSingleton(Configuration);

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<MovieDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                    


            services.AddScoped<IMovieDataStore, SqlMovieStore>();
            services.AddSingleton<IGreeter, Greeter>();
        }

        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env)
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
            app.UseMvc();
        }
    }
}

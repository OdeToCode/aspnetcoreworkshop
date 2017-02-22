
using AtTheMovies.Middleware;

namespace Microsoft.AspNetCore.Builder
{
    public static class MiddlewareExtendions
    {
        public static IApplicationBuilder UseGreeter(
            this IApplicationBuilder app, GreeterOptions options = null)
        {
            if (options == null)
            {
                options = new GreeterOptions {Path = "/greet", Message = "A Defaiult message"};
            }

            app.UseMiddleware<GreetingMiddleware>(options);

            return app;
        }
    }
}
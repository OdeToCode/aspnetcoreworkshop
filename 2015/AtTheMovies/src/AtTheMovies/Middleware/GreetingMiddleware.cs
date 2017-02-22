using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using AtTheMovies.Services;
using Microsoft.AspNetCore.Http;

namespace AtTheMovies.Middleware
{
    public class GreeterOptions
    {
        public string Path { get; set; }
        public string Message { get; set; }
    }

    public class GreetingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly GreeterOptions _options;

        public GreetingMiddleware(RequestDelegate next, GreeterOptions options)
        {
            _next = next;
            _options = options;
        }

        public Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(_options.Path))
            {
                return context.Response.WriteAsync(_options.Message);
            }
            return _next(context);
        }
    }
}

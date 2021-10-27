using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace merchandise_service.Configuration.Middlewares
{
    public class ReadyMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ReadyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync(StatusCodes.Status200OK.ToString());
        }
    }
}
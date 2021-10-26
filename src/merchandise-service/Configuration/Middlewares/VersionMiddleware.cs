using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace merchandise_service.Configuration.Middlewares
{
    public class VersionMiddleware
    {
        private readonly RequestDelegate _next;
        
        public VersionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1";
            string serviceName = Assembly.GetExecutingAssembly().GetName().Name ?? "NoName";
            await context.Response.WriteAsync($"\"version\":\"{version}\", \"serviceName\":\"{serviceName}\"");
        }
    }
}
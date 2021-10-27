using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace merchandise_service.Configuration.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1";
            string serviceName = Assembly.GetExecutingAssembly().GetName().Name ?? "NoName";
            await context.Response.WriteAsync($"\"version\":\"{version}\", \"serviceName\":\"{serviceName}\"");
        }
    }
}
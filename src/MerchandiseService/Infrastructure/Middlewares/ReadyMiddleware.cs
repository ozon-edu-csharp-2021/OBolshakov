using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
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
            context.Response.Headers.Add("test", "da");
            await context.Response.WriteAsync(StatusCodes.Status200OK.ToString());
            //await _next(context);
        }
    }
}
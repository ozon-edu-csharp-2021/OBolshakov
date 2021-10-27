using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace merchandise_service.Configuration.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
            await _next(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.ContentLength > 0)
                {
                    var requestHead = context.Request.Headers.ToString();
                    var requestRoute = context.Request.RouteValues;
                    _logger.LogInformation($"Request head: {requestHead}");
                    _logger.LogInformation($"Request route: {requestRoute}");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "The request could not be read.");
            }
        }
    }
}
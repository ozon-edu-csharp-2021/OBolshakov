using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogRequest(context);
            await _next(context);
        }

        private void LogRequest(HttpContext context)
        {
            try
            {
                var requestHead = context.Request.Headers.ToString();
                var requestRoute = context.Request.RouteValues;
                _logger.LogInformation($"Request head: {requestHead}");
                _logger.LogInformation($"Request route: {requestRoute}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "The request could not be read.");
            }
        }
    }
}
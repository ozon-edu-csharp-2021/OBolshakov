using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogRequest(context);
            await _next(context);
            LogResponse(context);
        }

        private void LogRequest(HttpContext context)
        {
            try
            {
                var requestRoute = context.Request.Path.Value;
                var requestHeader = new StringBuilder();
                foreach (var header in context.Request.Headers)
                {
                    requestHeader.Append($"{header.Key}:{header.Value.ToString()} ");
                }
                _logger.LogInformation($"Request route: {requestRoute}");
                _logger.LogInformation($"Request head: {requestHeader}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "The request could not be read.");
            }
        }
        
        private void LogResponse(HttpContext context)
        {
            try
            {
                var responseHeader = new StringBuilder();
                foreach (var header in context.Response.GetTypedHeaders().Headers)
                {
                    responseHeader.Append($"{header.Key}:{header.Value.ToString()} ");
                }
                _logger.LogInformation($"Response head: {responseHeader}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "The response could not be read.");
            }
        }
    }
}
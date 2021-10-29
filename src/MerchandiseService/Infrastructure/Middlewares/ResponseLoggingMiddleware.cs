using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogResponse(context);
            await _next(context);
        }

        private void LogResponse(HttpContext context)
        {
            try
            {
                var responseHead = context.Response.Headers.ToString();
                _logger.LogInformation($"Response head: {responseHead}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "The response could not be read.");
            }
        }
    }
}
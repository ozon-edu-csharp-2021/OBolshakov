using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace merchandise_service.Configuration.Middlewares
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogResponse(context);
            await _next(context);
        }

        private async Task LogResponse(HttpContext context)
        {
            try
            {
                if (context.Request.ContentLength > 0)
                {
                    var requestHead = context.Response.Headers.ToString();
                    _logger.LogInformation($"Response head: {requestHead}");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "The response could not be read.");
            }
        }
    }
}
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Presentations.Shared.Middlewares
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

        public async Task Invoke(HttpContext context, ILogService logService)
        {
            var method = context.Request.Method;
            var path = context.Request.Path;

            RequestSource logSource = path.StartsWithSegments("/api") ? RequestSource.Api : RequestSource.Mvc;

            _logger.LogInformation($"[{logSource}] Received request: {method} {path} at source {logSource}");

            await logService.LogRequestAsync(method, path, logSource);

            await _next(context);
        }
    }
}

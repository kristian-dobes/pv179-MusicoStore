using BusinessLayer.Services.Interfaces;

namespace WebAPI.Middlewares
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

            _logger.LogInformation($"Received request: {method} {path}");

            await logService.LogRequestAsync(method, path);

            await _next(context);
        }
    }
}

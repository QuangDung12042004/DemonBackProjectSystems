using System.Diagnostics;

namespace DemonBackProjectSystems.Api.Middlewares
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
            // Bấm giờ bắt đầu nhận Request
            var stopwatch = Stopwatch.StartNew();

            _logger.LogInformation("🚀 [Bắt đầu] {Method} {Url}",
                context.Request.Method, context.Request.Path);

            // Cho request đi tiếp vào Controller xử lý
            await _next(context);

            // Bấm giờ kết thúc
            stopwatch.Stop();

            _logger.LogInformation("✅ [Kết thúc] {Method} {Url} | Status: {StatusCode} | Thời gian: {ElapsedMilliseconds}ms",
                context.Request.Method, context.Request.Path, context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
        }
    }
}

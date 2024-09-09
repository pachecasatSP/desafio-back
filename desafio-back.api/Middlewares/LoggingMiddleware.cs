using Serilog;
using System.Diagnostics;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Serilog.ILogger _logger;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
        _logger = Log.ForContext<LoggingMiddleware>();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        await _next(context);

        stopwatch.Stop();

        var logDetails = new
        {
            RequestMethod = context.Request.Method,
            RequestPath = context.Request.Path,
            context.Response.StatusCode,
            stopwatch.ElapsedMilliseconds
        };

        _logger.Information("Request handled: {@LogDetails}", logDetails);
    }
}

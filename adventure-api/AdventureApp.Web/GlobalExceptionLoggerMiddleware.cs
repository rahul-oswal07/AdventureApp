public class GlobalExceptionLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionLoggerMiddleware> _logger;

    public GlobalExceptionLoggerMiddleware(RequestDelegate next, ILogger<GlobalExceptionLoggerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync($"An error has occurred");
        }
    }
}

namespace Globomantics.Survey.Middleware
{
    public class HttpMethodValidationMiddleware
    {
        private static readonly List<string> _allowedMethods = new List<string>
        {
            "GET",
            "POST"
        };

        private readonly ILogger<HttpMethodValidationMiddleware> _logger;

        private readonly RequestDelegate _next;

        public HttpMethodValidationMiddleware(RequestDelegate next, ILogger<HttpMethodValidationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!_allowedMethods.Contains(context.Request.Method.ToUpper()))
            {
                _logger.LogWarning("Invalid HTTP method used: {0}.", context.Request.Method);
                throw new InvalidOperationException(String.Format("Invalid HTTP method used: {0}.", context.Request.Method));
            }

            await _next(context);
        }
    }

    public static class HttpMethodValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpMethodValidation(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpMethodValidationMiddleware>();
        }
    }
}
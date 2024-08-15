using System.Net;

namespace Powerplant.Api.Middlewares
{
    public class ExceptionHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        //private readonly ILogger _logger;

        //public ExceptionHandlerMiddleware(RequestDelegate next, ILogger logger)
        //{
        //    _next = next;
        //    _logger = logger;
        //}

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong: {e.Message}");
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return httpContext.Response.WriteAsync(new
            {
                httpContext.Response.StatusCode,
                Message = "Something went wrong !Internal Server Error" + e.Message
            }.ToString());
        }
    }
}

using System.Net;
using WebApi.Models;

namespace WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, ex.GetType().Name);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, string exceptionType)
        {
            context.Response.ContentType = "application/json";

            switch (exceptionType)
            {
                case "ArgumentException":
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case "KeyNotFoundException":
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;

                case "AggregateException":
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }


            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}

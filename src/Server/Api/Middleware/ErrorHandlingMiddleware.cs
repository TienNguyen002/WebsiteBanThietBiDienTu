using Domain.Constants;
using System.Net;

namespace Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
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
                _logger.LogInformation(LogManagements.ExceptionMSG + ex.Message);
                _logger.LogInformation(LogManagements.InnerExceptionMSG + ex.InnerException);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var statusCode = (int)HttpStatusCode.InternalServerError;

            if(exception is NotImplementedException) statusCode = (int)HttpStatusCode.NotImplemented;
            else if(exception is ArgumentException) statusCode = (int)HttpStatusCode.BadRequest;
            else if(exception is ArgumentNullException) statusCode = (int)HttpStatusCode.BadRequest;
            else if(exception is NullReferenceException) statusCode = (int)HttpStatusCode.BadRequest;

            context.Response.StatusCode = statusCode;
            
            var error = new Error
            {
                StatusCode = statusCode.ToString(),
                Message = exception.Message,
            };
            return context.Response.WriteAsync(error.ToString());
        }
    }
}

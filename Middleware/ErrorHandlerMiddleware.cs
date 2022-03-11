using FluentValidation;
using System.Net;
using TodoAPI.Domain.Exceptions;

namespace TodoAPI.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var errorMessage = "";

                switch (error)
                {
                    case DomainException domainException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorMessage = domainException.Message;
                        break;
                    case ValidationException validationException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorMessage = string.Join(",", validationException.Errors.Select(er => er.ErrorMessage));
                        break;
                    case Exception e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorMessage = "Something went wrong, try later or contact with police department";  
                        break;
                }

                await response.WriteAsJsonAsync(new { message = errorMessage });
            }
        }
    }
}

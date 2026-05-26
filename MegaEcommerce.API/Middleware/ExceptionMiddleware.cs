using MegaEcommerce.Application.DTO.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace MegaEcommerce.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
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
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext context,Exception ex)
        {
            context.Response.ContentType = "application/json";
            int statusCode = ex switch
            {
                NotFoundException => (int) HttpStatusCode.NotFound,

                BadRequestException => (int) HttpStatusCode.BadRequest,

                _ => (int) HttpStatusCode.InternalServerError
            };

            string message = ex.Message ?? "Something went wrong";

            var response = ApiResponse<object>.ErrorResponse(message,statusCode);

        }

    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
            
        }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}

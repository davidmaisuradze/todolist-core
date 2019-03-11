using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TodoList.Domain.Configuration;

namespace TodoList.Api.Core.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
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
                await handleExceptionAsync(httpContext, ex);
            }
        }

        private static Task handleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;

            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Error = exception.Message
            }.ToString());
        }
    }
}

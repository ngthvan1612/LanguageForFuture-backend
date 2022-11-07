using LFF.Core.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace LFF.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json"; ;

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            if (exception is BaseDomainException)
            {
                var e = exception as BaseDomainException;
                context.Response.StatusCode = e.Error.Code;
                var result = JsonSerializer.Serialize(e.Error, serializeOptions);
                await context.Response.WriteAsync(result);
            }
            else
            {
                context.Response.StatusCode = 400; ;
                var domainException = BaseDomainException.BadRequest("Lỗi hệ thống");
                var tempRecursive = exception;
                while (tempRecursive != null)
                {
                    domainException.Error.addMessage(tempRecursive.Message);
                    domainException.Error.addMessage(tempRecursive.StackTrace ?? "");
                    tempRecursive = tempRecursive.InnerException;
                }
                await context
                    .Response
                    .WriteAsync(JsonSerializer.Serialize(domainException.Error, serializeOptions));
            }
        }
    }
}

using LFF.Core.Base;
using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

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

            if (exception is BaseDomainException)
            {
                var e = exception as BaseDomainException;
                context.Response.StatusCode = e.Error.Code;
                var result = JsonConvert.SerializeObject(e.Error, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
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
                    .WriteAsync(JsonConvert.SerializeObject(domainException.Error, Formatting.Indented, new JsonSerializerSettings()
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }));
            }
        }
    }
}

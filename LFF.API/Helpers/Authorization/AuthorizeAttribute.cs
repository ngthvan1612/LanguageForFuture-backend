using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Text.Json;

namespace LFF.API.Helpers.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] roles;

        public AuthorizeAttribute(params string[] roles)
        {
            this.roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (AbstractUser)context.HttpContext.Items["User"];
            if (!user.IsAuthenticated())
            {
                context.HttpContext.Response.StatusCode = 401;
                var result = new ErrorResponseModelBase();
                result.addMessage("Chưa đăng nhập");
                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                context.Result = new JsonResult(result, serializeOptions);
            }
            else
            {
                if (!this.roles.Contains(user.Role))
                {
                    context.HttpContext.Response.StatusCode = 403;
                    var result = new ErrorResponseModelBase();
                    var serializeOptions = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    };
                    result.addMessage("Bạn không có quyền truy cập vào trang này");
                    context.Result = new JsonResult(result, serializeOptions);
                }
            }
        }
    }
}

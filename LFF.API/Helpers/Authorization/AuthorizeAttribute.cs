using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
                context.Result = new ContentResult() { Content = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }), ContentType = "application/json" };
            }
            else
            {
                if (!this.roles.Contains(user.Role))
                {
                    context.HttpContext.Response.StatusCode = 403;
                    var result = new ErrorResponseModelBase();
                    result.addMessage("Bạn không có quyền truy cập vào trang này");
                    context.Result = new ContentResult()
                    {
                        Content = JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings()
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }),
                        ContentType = "application/json"
                    };
                }
            }
        }
    }
}

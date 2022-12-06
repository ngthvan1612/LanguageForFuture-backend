using LFF.API.Helpers.Authorization.Users;
using LFF.Core.DTOs.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LFF.API.Extensions
{
    public static class ApiControllerExtensions
    {

        public static IEnumerable<SearchQueryItem> TransferHttpQueriesToDomainSearchQueries(this ControllerBase controller)
        {
            List<SearchQueryItem> result = new List<SearchQueryItem>();
            result.AddRange(controller.HttpContext.Request.Query.Select(u => new SearchQueryItem(new KeyValuePair<string, IList<string>>(u.Key, u.Value))));
            return result;
        }

        public static AbstractUser GetCurrentLoginedUser(this ControllerBase controller)
        {
            var user = (AbstractUser)(controller.HttpContext.Items["User"]);
            return user;
        }
    }
}

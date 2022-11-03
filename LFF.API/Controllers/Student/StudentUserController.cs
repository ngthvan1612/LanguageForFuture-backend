using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Student
{
    [Authorize(UserRoles.Student)]
    [ApiController]
    [Route("api/v1.0/student/user")]
    [ApiExplorerSettings(GroupName = "student-controller")]
    public class StudentUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public StudentUserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListUsers()
        {
            var queries = this.TransferHttpQueriesToDomainSearchQueries();
            var result = await this._userService.ListUserAsync(queries);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var result = await this._userService.GetUserByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

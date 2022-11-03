using LFF.API.Extensions;
using LFF.Core.DTOs.Users.Requests;
using LFF.Core.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;

namespace LFF.API.Controllers.Teacher
{
    [Authorize(UserRoles.Teacher)]
    [ApiController]
    [Route("api/v1.0/teacher/user")]
    [ApiExplorerSettings(GroupName = "teacher-controller")]
    public class TeacherUserController : ControllerBase
    {
        private readonly IUserService _userService;

        public TeacherUserController(IUserService userService)
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

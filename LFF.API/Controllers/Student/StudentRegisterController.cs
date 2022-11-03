using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Services.RegisterServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Student
{
    [Authorize(UserRoles.Student)]
    [ApiController]
    [Route("api/v1.0/student/register")]
    [ApiExplorerSettings(GroupName = "student-controller")]
    public class StudentRegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public StudentRegisterController(IRegisterService registerService)
        {
            this._registerService = registerService;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListRegisters()
        {
            var queries = this.TransferHttpQueriesToDomainSearchQueries();
            var result = await this._registerService.ListRegisterAsync(queries);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRegister(Guid id)
        {
            var result = await this._registerService.GetRegisterByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

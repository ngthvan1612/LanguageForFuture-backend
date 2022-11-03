using LFF.API.Extensions;
using LFF.Core.DTOs.Tests.Requests;
using LFF.Core.Services.TestServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;

namespace LFF.API.Controllers.Student
{
    [Authorize(UserRoles.Student)]
    [ApiController]
    [Route("api/v1.0/student/test")]
    [ApiExplorerSettings(GroupName = "student-controller")]
    public class StudentTestController : ControllerBase
    {
        private readonly ITestService _testService;

        public StudentTestController(ITestService testService)
        {
            this._testService = testService;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListTests()
        {
            var queries = this.TransferHttpQueriesToDomainSearchQueries();
            var result = await this._testService.ListTestAsync(queries);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTest(Guid id)
        {
            var result = await this._testService.GetTestByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Services.StudentTestServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Student
{
    [Authorize(UserRoles.Student)]
    [ApiController]
    [Route("api/v1.0/student/studentTest")]
    [ApiExplorerSettings(GroupName = "student-controller")]
    public class StudentStudentTestController : ControllerBase
    {
        private readonly IStudentTestService _studentTestService;

        public StudentStudentTestController(IStudentTestService studentTestService)
        {
            this._studentTestService = studentTestService;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListStudentTests()
        {
            var queries = this.TransferHttpQueriesToDomainSearchQueries();
            var result = await this._studentTestService.ListStudentTestAsync(queries);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStudentTest(Guid id)
        {
            var result = await this._studentTestService.GetStudentTestByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

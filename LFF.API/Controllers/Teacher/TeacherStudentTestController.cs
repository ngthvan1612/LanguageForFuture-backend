using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Services.StudentTestServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Teacher
{
    [Authorize(UserRoles.Teacher)]
    [ApiController]
    [Route("api/v1.0/teacher/studentTest")]
    [ApiExplorerSettings(GroupName = "teacher-controller")]
    public class TeacherStudentTestController : ControllerBase
    {
        private readonly IStudentTestService _studentTestService;

        public TeacherStudentTestController(IStudentTestService studentTestService)
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

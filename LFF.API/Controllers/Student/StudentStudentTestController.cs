using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.DTOs.StudentTests.Requests;
using LFF.Core.Services.StudentTestServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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

        [HttpPost("")]
        public async Task<IActionResult> CreateStudentTest(CreateStudentTestRequest model)
        {
            // TODO: nhớ kiểm tra model.StudentId có phải người đăng nhập hiện tại hay không

            var result = await this._studentTestService.CreateStudentTestAsync(model);
            return this.StatusCode((int)result.GetStatusCode(), result);
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

        [HttpGet("history")]
        public async Task<IActionResult> GetStudentTestHistoryAsync()
        {
            var pars = this.TransferHttpQueriesToDomainSearchQueries();
            var studentId = Guid.Parse(pars.FirstOrDefault(u => u.Name == "studentId").Values[0]);
            var testId = Guid.Parse(pars.FirstOrDefault(u => u.Name == "testId").Values[0]);

            var result = await this._studentTestService.GetStudentTestHistory(studentId, testId);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{studentTestId:guid}/status")]
        public async Task<IActionResult> GetTestStatus(Guid studentTestId)
        {
            var result = await this._studentTestService.GetTestStatusAsync(studentTestId);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

using LFF.API.Extensions;
using LFF.Core.DTOs.StudentTests.Requests;
using LFF.Core.Services.StudentTestServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;

namespace LFF.API.Controllers.Admin
{
    [Authorize(UserRoles.Admin, UserRoles.Staff)]
    [ApiController]
    [Route("api/v1.0/admin/studentTest")]
    [ApiExplorerSettings(GroupName = "admin-controller")]
    public class AdminStudentTestController : ControllerBase
    {
        private readonly IStudentTestService _studentTestService;

        public AdminStudentTestController(IStudentTestService studentTestService)
        {
            this._studentTestService = studentTestService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateStudentTest(CreateStudentTestRequest model)
        {
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

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStudentTest(Guid id, UpdateStudentTestRequest model)
        {
            var result = await this._studentTestService.UpdateStudentTestByIdAsync(id, model);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudentTest(Guid id)
        {
            var result = await this._studentTestService.DeleteStudentTestByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

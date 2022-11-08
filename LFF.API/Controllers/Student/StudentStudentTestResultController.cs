using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.DTOs.StudentTestResults.Requests;
using LFF.Core.Services.StudentTestResultServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Student
{
    [Authorize(UserRoles.Student)]
    [ApiController]
    [Route("api/v1.0/student/studentTestResult")]
    [ApiExplorerSettings(GroupName = "student-controller")]
    public class StudentStudentTestResultController : ControllerBase
    {
        private readonly IStudentTestResultService _studentTestResultService;

        public StudentStudentTestResultController(IStudentTestResultService studentTestResultService)
        {
            this._studentTestResultService = studentTestResultService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateStudentTestResult(CreateStudentTestResultRequest model)
        {
            var result = await this._studentTestResultService.CreateStudentTestResultAsync(model);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("")]
        public async Task<IActionResult> ListStudentTestResults()
        {
            var queries = this.TransferHttpQueriesToDomainSearchQueries();
            var result = await this._studentTestResultService.ListStudentTestResultAsync(queries);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStudentTestResult(Guid id)
        {
            var result = await this._studentTestResultService.GetStudentTestResultByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStudentTestResult(Guid id, UpdateStudentTestResultRequest model)
        {
            var result = await this._studentTestResultService.UpdateStudentTestResultByIdAsync(id, model);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

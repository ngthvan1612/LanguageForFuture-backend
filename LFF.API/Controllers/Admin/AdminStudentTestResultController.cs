using LFF.API.Extensions;
using LFF.Core.DTOs.StudentTestResults.Requests;
using LFF.Core.Services.StudentTestResultServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Admin
{
    [ApiController]
    [Route("api/v1.0/admin/studentTestResult")]
    [//Authorize("")]
  [ApiExplorerSettings(GroupName = "admin-controller")]
    public class AdminStudentTestResultController : ControllerBase
    {
        private readonly IStudentTestResultService _studentTestResultService;

        public AdminStudentTestResultController(IStudentTestResultService studentTestResultService)
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

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudentTestResult(Guid id)
        {
            var result = await this._studentTestResultService.DeleteStudentTestResultByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

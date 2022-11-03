using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Services.QuestionServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Student
{
    [Authorize(UserRoles.Student)]
    [ApiController]
    [Route("api/v1.0/student/question")]
    [ApiExplorerSettings(GroupName = "student-controller")]
    public class StudentQuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public StudentQuestionController(IQuestionService questionService)
        {
            this._questionService = questionService;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListQuestions()
        {
            var queries = this.TransferHttpQueriesToDomainSearchQueries();
            var result = await this._questionService.ListQuestionAsync(queries);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetQuestion(Guid id)
        {
            var result = await this._questionService.GetQuestionByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

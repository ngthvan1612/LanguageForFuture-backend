using LFF.API.Extensions;
using LFF.Core.DTOs.Questions.Requests;
using LFF.Core.Services.QuestionServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Teacher
{
    [ApiController]
    [Route("api/v1.0/teacher/question")]
    [//Authorize("")]
  [ApiExplorerSettings(GroupName = "teacher-controller")]
    public class TeacherQuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public TeacherQuestionController(IQuestionService questionService)
        {
            this._questionService = questionService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateQuestion(CreateQuestionRequest model)
        {
            var result = await this._questionService.CreateQuestionAsync(model);
            return this.StatusCode((int)result.GetStatusCode(), result);
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

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateQuestion(Guid id, UpdateQuestionRequest model)
        {
            var result = await this._questionService.UpdateQuestionByIdAsync(id, model);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            var result = await this._questionService.DeleteQuestionByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

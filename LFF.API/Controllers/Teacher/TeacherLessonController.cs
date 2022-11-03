using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.DTOs.Lessons.Requests;
using LFF.Core.Services.LessonServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Teacher
{
    [Authorize(UserRoles.Teacher)]
    [ApiController]
    [Route("api/v1.0/teacher/lesson")]
    [ApiExplorerSettings(GroupName = "teacher-controller")]
    public class TeacherLessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public TeacherLessonController(ILessonService lessonService)
        {
            this._lessonService = lessonService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateLesson(CreateLessonRequest model)
        {
            var result = await this._lessonService.CreateLessonAsync(model);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("")]
        public async Task<IActionResult> ListLessons()
        {
            var queries = this.TransferHttpQueriesToDomainSearchQueries();
            var result = await this._lessonService.ListLessonAsync(queries);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetLesson(Guid id)
        {
            var result = await this._lessonService.GetLessonByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateLesson(Guid id, UpdateLessonRequest model)
        {
            var result = await this._lessonService.UpdateLessonByIdAsync(id, model);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteLesson(Guid id)
        {
            var result = await this._lessonService.DeleteLessonByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

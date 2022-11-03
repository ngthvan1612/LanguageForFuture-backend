using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Services.LessonServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Student
{
    [Authorize(UserRoles.Student)]
    [ApiController]
    [Route("api/v1.0/student/lesson")]
    [ApiExplorerSettings(GroupName = "student-controller")]
    public class StudentLessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public StudentLessonController(ILessonService lessonService)
        {
            this._lessonService = lessonService;
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
    }
}

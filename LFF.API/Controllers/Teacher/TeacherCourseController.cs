using LFF.API.Extensions;
using LFF.Core.DTOs.Courses.Requests;
using LFF.Core.Services.CourseServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;

namespace LFF.API.Controllers.Teacher
{
    [Authorize(UserRoles.Teacher)]
    [ApiController]
    [Route("api/v1.0/teacher/course")]
    [ApiExplorerSettings(GroupName = "teacher-controller")]
    public class TeacherCourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public TeacherCourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCourse(CreateCourseRequest model)
        {
            var result = await this._courseService.CreateCourseAsync(model);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("")]
        public async Task<IActionResult> ListCourses()
        {
            var queries = this.TransferHttpQueriesToDomainSearchQueries();
            var result = await this._courseService.ListCourseAsync(queries);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCourse(Guid id)
        {
            var result = await this._courseService.GetCourseByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCourse(Guid id, UpdateCourseRequest model)
        {
            var result = await this._courseService.UpdateCourseByIdAsync(id, model);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var result = await this._courseService.DeleteCourseByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

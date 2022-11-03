using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Services.CourseServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Student
{
    [Authorize(UserRoles.Student)]
    [ApiController]
    [Route("api/v1.0/student/course")]
    [ApiExplorerSettings(GroupName = "student-controller")]
    public class StudentCourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public StudentCourseController(ICourseService courseService)
        {
            this._courseService = courseService;
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
    }
}

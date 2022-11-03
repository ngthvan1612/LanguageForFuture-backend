using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Services.LectureServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Student
{
    [Authorize(UserRoles.Student)]
    [ApiController]
    [Route("api/v1.0/student/lecture")]
    [ApiExplorerSettings(GroupName = "student-controller")]
    public class StudentLectureController : ControllerBase
    {
        private readonly ILectureService _lectureService;

        public StudentLectureController(ILectureService lectureService)
        {
            this._lectureService = lectureService;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListLectures()
        {
            var queries = this.TransferHttpQueriesToDomainSearchQueries();
            var result = await this._lectureService.ListLectureAsync(queries);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetLecture(Guid id)
        {
            var result = await this._lectureService.GetLectureByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

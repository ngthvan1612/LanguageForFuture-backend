using LFF.API.Extensions;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;
using LFF.Core.Services.ClassroomServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Student
{
    [Authorize(UserRoles.Student)]
    [ApiController]
    [Route("api/v1.0/student/classroom")]
    [ApiExplorerSettings(GroupName = "student-controller")]
    public class StudentClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public StudentClassroomController(IClassroomService classroomService)
        {
            this._classroomService = classroomService;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListClassrooms()
        {
            var queries = this.TransferHttpQueriesToDomainSearchQueries();
            var result = await this._classroomService.ListClassroomAsync(queries);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetClassroom(Guid id)
        {
            var result = await this._classroomService.GetClassroomByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

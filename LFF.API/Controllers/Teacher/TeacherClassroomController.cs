using LFF.API.Extensions;
using LFF.Core.DTOs.Classrooms.Requests;
using LFF.Core.Services.ClassroomServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LFF.API.Helpers.Authorization;
using LFF.API.Helpers.Authorization.Users;

namespace LFF.API.Controllers.Teacher
{
    [Authorize(UserRoles.Teacher)]
    [ApiController]
    [Route("api/v1.0/teacher/classroom")]
    [ApiExplorerSettings(GroupName = "teacher-controller")]
    public class TeacherClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public TeacherClassroomController(IClassroomService classroomService)
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

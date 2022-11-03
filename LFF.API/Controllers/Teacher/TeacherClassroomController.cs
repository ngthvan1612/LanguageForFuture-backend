using LFF.API.Extensions;
using LFF.Core.DTOs.Classrooms.Requests;
using LFF.Core.Services.ClassroomServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Teacher
{
    [ApiController]
    [Route("api/v1.0/teacher/classroom")]
    public class TeacherClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public TeacherClassroomController(IClassroomService classroomService)
        {
            this._classroomService = classroomService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateClassroom(CreateClassroomRequest model)
        {
            var result = await this._classroomService.CreateClassroomAsync(model);
            return this.StatusCode((int)result.GetStatusCode(), result);
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

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateClassroom(Guid id, UpdateClassroomRequest model)
        {
            var result = await this._classroomService.UpdateClassroomByIdAsync(id, model);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteClassroom(Guid id)
        {
            var result = await this._classroomService.DeleteClassroomByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

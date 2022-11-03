using LFF.API.Extensions;
using LFF.Core.DTOs.Classrooms.Requests;
using LFF.Core.Services.ClassroomServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Common
{
    [ApiController]
    [Route("api/v1.0/common/classroom")]
    [ApiExplorerSettings(GroupName = "common-controller")]
    public class CommonClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public CommonClassroomController(IClassroomService classroomService)
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

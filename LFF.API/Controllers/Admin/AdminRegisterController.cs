using LFF.API.Extensions;
using LFF.Core.DTOs.Registers.Requests;
using LFF.Core.Services.RegisterServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LFF.API.Controllers.Admin
{
    [ApiController]
    [Route("api/v1.0/admin/register")]
    [//Authorize("")]
  [ApiExplorerSettings(GroupName = "admin-controller")]
    public class AdminRegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public AdminRegisterController(IRegisterService registerService)
        {
            this._registerService = registerService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateRegister(CreateRegisterRequest model)
        {
            var result = await this._registerService.CreateRegisterAsync(model);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("")]
        public async Task<IActionResult> ListRegisters()
        {
            var queries = this.TransferHttpQueriesToDomainSearchQueries();
            var result = await this._registerService.ListRegisterAsync(queries);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRegister(Guid id)
        {
            var result = await this._registerService.GetRegisterByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateRegister(Guid id, UpdateRegisterRequest model)
        {
            var result = await this._registerService.UpdateRegisterByIdAsync(id, model);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRegister(Guid id)
        {
            var result = await this._registerService.DeleteRegisterByIdAsync(id);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

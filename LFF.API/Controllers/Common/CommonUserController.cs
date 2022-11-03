using System.Threading.Tasks;
using LFF.API.Helpers;
using LFF.API.Helpers.Authorization;
using LFF.Core.DTOs.Users.Requests;
using LFF.Core.DTOs.Users.Responses;
using LFF.Core.Entities;
using LFF.Core.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LFF.API.Controllers.Common
{
    [ApiController]
    [Route("api/v1.0/common/user")]
    [ApiExplorerSettings(GroupName = "common-controller")]
    public class CommonUserController : Controller
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;

        public CommonUserController(IUserService _userService, IOptions<AppSettings> _appSettings)
        {
            this._userService = _userService;
            this._appSettings = _appSettings.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(UserLoginRequest model)
        {
            var result = (AuthenticatedUserResponse)await this._userService.UserLogin(model);
            result.AccessToken = GenerateJwtToken.GetJwtToken(result.GetStoredUser(), _appSettings);
            return this.StatusCode((int)result.GetStatusCode(), result);
        }
    }
}

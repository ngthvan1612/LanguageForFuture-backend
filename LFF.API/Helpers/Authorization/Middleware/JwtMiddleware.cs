using LFF.Core.Repositories;
using LFF.Helpers.Authorization.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFF.API.Helpers.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            this._next = next;
            this.appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepository)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                await this.AttemptUser(context, userRepository, token);
            }
            else
            {
                context.Items["User"] = new AnonymousUser();
            }

            await _next(context);
        }

        private async Task AttemptUser(HttpContext context, IUserRepository userRepository, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "Id").Value);

                var dbUser = await userRepository.GetByIdAsync(userId);
                if (dbUser is null)
                {
                    context.Items["User"] = new AnonymousUser();
                }
                else
                {
                    context.Items["User"] = dbUser.Role switch
                    {
                        "ADMIN" => new AdminUser(dbUser),
                        "TEACHER" => new TeacherUser(dbUser),
                        "STUDENT" => new StudentUser(dbUser),
                        "STAFF" => new StaffUser(dbUser),
                        _ => throw new Exception("[AUTH]: Conflict database!!!"),
                    };
                }
            }
            catch
            {
                context.Items["User"] = new AnonymousUser();
            }
        }
    }
}

using Asp.Versioning;
using EAApplication.Auth.Commands;
using EAApplication.Auth.DTOs;
using EAService.Users;
using EAWebAPI.EACustomizing.EAAttribute;
using EAWebAPI.EACustomizing.EAController.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace EAWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class AuthController : EAV1BaseController
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [MapToApiVersion("1.0")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginV1([FromBody] LoginUserDto loginUserDto)
        {
            //Try login
            var loggedUser = await Mediator.Send(new LoginUserCommand(loginUserDto));
            return Ok(loggedUser);
        }
        [MapToApiVersion("1.0")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterV1([FromBody] RegisterDto registerDto)
        {

            //Try login
            var registeredUser = await Mediator.Send(new RegisterUserCommand(registerDto));
            return Ok(registeredUser);
        }
        [MapToApiVersion("1.0")]
        [EAAuthorize("SystemAdmin")]
        [HttpGet]
        public IActionResult TestV1()
        {
            //Get token from header

            string token = Request.Headers["Authorization"];
            if (token.StartsWith("Bearer"))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }
            var handler = new JwtSecurityTokenHandler();

            //Returns all claims present in the token
            JwtSecurityToken jwt = handler.ReadJwtToken(token);

            var claims = "List of Claims: \n\n";
            foreach (var claim in jwt.Claims)
            {
                claims += $"{claim.Type}:{claim.Value}\n";
            }
            return Ok(claims);
        }
    }
}

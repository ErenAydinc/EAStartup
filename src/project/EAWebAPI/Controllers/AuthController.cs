using EAApplication.Users.Commands;
using EAApplication.Users.DTOs;
using EAApplication.Users.Queries;
using EADomain;
using EAService.Users;
using EAWebAPI.EAAttribute;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace EAWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;
        public AuthController(IUserService userService, IMediator mediator)
        {
            _mediator = mediator;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            //Error checks
            if (String.IsNullOrEmpty(loginUserDto.Email))
            {
                return BadRequest(new { message = "User email needs to entered" });
            }
            else if (String.IsNullOrEmpty(loginUserDto.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            //Try login
            var loggedUser = await _mediator.Send(new LoginUserCommand(loginUserDto));
            return Ok(loggedUser);


        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            //Error checks
            if (String.IsNullOrEmpty(registerUser.Email))
            {
                return BadRequest(new { message = "User email needs to entered" });
            }
            else if (String.IsNullOrEmpty(registerUser.FirstName))
            {
                return BadRequest(new { message = "First Name needs to entered" });
            }
            else if (String.IsNullOrEmpty(registerUser.LastName))
            {
                return BadRequest(new { message = "Last Name needs to entered" });
            }
            else if (String.IsNullOrEmpty(registerUser.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            //Try login
            var registeredUser = await _userService.Register(registerUser);

            //Return responses
            if (registeredUser != null)
            {
                return Ok(registeredUser);
            }
            return BadRequest(new { message = "User registration unsuccessful" });
        }
        [EAAuthorize("SystemAdmin")]
        [HttpGet]
        public IActionResult Test()
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

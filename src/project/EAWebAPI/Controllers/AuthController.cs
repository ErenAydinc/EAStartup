using EACrossCuttingConcerns.Exception;
using EADomain;
using EASecurity.Authorization;
using EAService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace EAWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUser user)
        {
            //Error checks
            if (String.IsNullOrEmpty(user.Email))
            {
                return BadRequest(new { message = "User email needs to entered" });
            }
            else if (String.IsNullOrEmpty(user.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            //Try login
            var loggedUser = await _userService.Login(new User(null,null,user.Email,null,true,null,user.Password));

            //Return responses
            if (loggedUser!=null)
            {
                return Ok(loggedUser);
            }
            return BadRequest(new { message = "User login unsuccessful" });
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser user)
        {
            //Error checks
            if (String.IsNullOrEmpty(user.Email))
            {
                return BadRequest(new { message = "User email needs to entered" });
            }
            else if (String.IsNullOrEmpty(user.FirstName))
            {
                return BadRequest(new { message = "First Name needs to entered" });
            }
            else if (String.IsNullOrEmpty(user.LastName))
            {
                return BadRequest(new { message = "Last Name needs to entered" });
            }
            else if (String.IsNullOrEmpty(user.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            //Try login
            var registeredUser = await _userService.Register(new User(user.FirstName,user.LastName,user.Email,user.Roles,true,null,user.Password));

            //Return responses
            if (registeredUser != null)
            {
                return Ok(registeredUser);
            }
            return BadRequest(new { message = "User registration unsuccessful" });
        }
        [Authorize(Roles ="User")]
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

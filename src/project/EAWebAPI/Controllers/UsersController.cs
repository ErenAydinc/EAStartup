using EAApplication.Users.Commands;
using EAApplication.Users.DTOs;
using EAApplication.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new UserGetByIdQuery { Id = id };
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        {
            var query = new GetAllUserQuery { PageIndex = pageIndex, PageSize = pageSize };
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserDto createUserDto)
        {
            var command = new AddUserCommand(createUserDto);
            var user = await _mediator.Send(command);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserDto updateUserDto)
        {
            var command = new UpdateUserCommand(updateUserDto);
            var user = await _mediator.Send(command);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteUserDto deleteUserDto)
        {
            var command = new DeleteUserCommand(deleteUserDto);
            var user = await _mediator.Send(command);
            return Ok(user);
        }
        #endregion
    }
}

using Asp.Versioning;
using EAApplication.Users.Commands;
using EAApplication.Users.DTOs;
using EAApplication.Users.Queries;
using EAService.UserOperationClaims;
using EAWebAPI.EACustomizing.EAController.v2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAWebAPI.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class UsersController : EAV2BaseController
    {
        #region Fields
        private readonly IUserOperationClaimService _userOperationClaimService;
        #endregion

        #region Ctor
        public UsersController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }
        #endregion

        #region Methods
        [MapToApiVersion("2.0")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdUserQuery { Id = id };
            var user = await Mediator.Send(query);
            return Ok(user);
        }

        [MapToApiVersion("2.0")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        {
            var query = new GetAllUserQuery { PageIndex = pageIndex, PageSize = pageSize };
            var users = await Mediator.Send(query);
            return Ok(users);
        }

        [MapToApiVersion("2.0")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserDto createUserDto)
        {
            var command = new CreateUserCommand(createUserDto);
            var user = await Mediator.Send(command);
            return Ok(user);
        }

        [MapToApiVersion("2.0")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserDto updateUserDto)
        {
            var command = new UpdateUserCommand(updateUserDto);
            var user = await Mediator.Send(command);
            return Ok(user);
        }

        [MapToApiVersion("2.0")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteUserDto deleteUserDto)
        {
            var command = new DeleteUserCommand(deleteUserDto);
            var user = await Mediator.Send(command);
            return Ok(user);
        }

        [MapToApiVersion("2.0")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> DeleteRangeUserOperationClaims(int userId)
        {
            var userOperationClaims = await _userOperationClaimService.DeleteRangeByUserId(userId);
            return Ok(userOperationClaims);
        }
        #endregion
    }
}

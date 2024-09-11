using Asp.Versioning;
using EAApplication.UserOperationClaims.Commands;
using EAApplication.UserOperationClaims.DTOs;
using EAApplication.UserOperationClaims.Queries;
using EAWebAPI.EACustomizing.EAController.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class UserOperationClaimsController : EAV1BaseController
    {
        #region Fields


        #endregion

        #region Ctors

        #endregion

        #region Methods
        [MapToApiVersion("1.0")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateV1(CreateUserOperationClaimDto createUserOperationClaimDto)
        {
            var command = new CreateUserOperationClaimCommand(createUserOperationClaimDto);
            var userOperationClaim = await Mediator.Send(command);
            return Ok(userOperationClaim);
        }
        [MapToApiVersion("1.0")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateV1(UpdateUserOperationClaimDto updateUserOperationClaimDto)
        {
            var command = new UpdateUserOperationClaimCommand(updateUserOperationClaimDto);
            var userOperationClaim = await Mediator.Send(command);
            return Ok(userOperationClaim);
        }
        [MapToApiVersion("1.0")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteV1(DeleteUserOperationClaimDto deleteUserOperationClaimDto)
        {
            var command = new DeleteUserOperationClaimCommand(deleteUserOperationClaimDto);
            var userOperationClaim = await Mediator.Send(command);
            return Ok(userOperationClaim);
        }
        [MapToApiVersion("1.0")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllV1(int pageIndex, int pageSize)
        {
            var query = new GetAllUserOperationClaimQuery { PageIndex = pageIndex, PageSize = pageSize };
            var userOperationClaims = await Mediator.Send(query);
            return Ok(userOperationClaims);

        }
        [MapToApiVersion("1.0")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdV1(int id)
        {
            var query = new GetByIdUserOperationClaimQuery { Id=id};
            var userOperationClaim =await Mediator.Send(query);
            return Ok(userOperationClaim);
        }
        #endregion
    }
}

using Asp.Versioning;
using EAApplication.UserOperationClaims.Commands;
using EAApplication.UserOperationClaims.DTOs;
using EAApplication.UserOperationClaims.Queries;
using EAWebAPI.EACustomizing.EAController.v2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EAWebAPI.Controllers.v2
{
    [ApiVersion("2.0",Deprecated =true)]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class UserOperationClaimsController : EAV2BaseController
    {
        #region Fields


        #endregion

        #region Ctors

        #endregion

        #region Methods

        [MapToApiVersion("2.0")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateUserOperationClaimDto createUserOperationClaimDto)
        {
            var command = new CreateUserOperationClaimCommand(createUserOperationClaimDto);
            var userOperationClaim = await Mediator.Send(command);
            return Ok(userOperationClaim);
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Update(UpdateUserOperationClaimDto updateUserOperationClaimDto)
        {
            var command = new UpdateUserOperationClaimCommand(updateUserOperationClaimDto);
            var userOperationClaim = await Mediator.Send(command);
            return Ok(userOperationClaim);
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(DeleteUserOperationClaimDto deleteUserOperationClaimDto)
        {
            var command = new DeleteUserOperationClaimCommand(deleteUserOperationClaimDto);
            var userOperationClaim = await Mediator.Send(command);
            return Ok(userOperationClaim);
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        {
            var query = new GetAllUserOperationClaimQuery { PageIndex = pageIndex, PageSize = pageSize };
            var userOperationClaims = await Mediator.Send(query);
            return Ok(userOperationClaims);

        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdUserOperationClaimQuery { Id=id};
            var userOperationClaim =await Mediator.Send(query);
            return Ok(userOperationClaim);
        }
        #endregion
    }
}

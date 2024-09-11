using Asp.Versioning;
using EAApplication.OperationClaims.Commands;
using EAApplication.OperationClaims.DTOs;
using EAApplication.OperationClaims.Queries;
using EAWebAPI.EACustomizing.EAController.v2;
using Microsoft.AspNetCore.Mvc;

namespace EAWebAPI.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class OperationClaimsController : EAV2BaseController
    {
        #region Fields


        #endregion

        #region Ctor

        #endregion

        #region Methods

        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        {
            var query = new GetAllOperationClaimQuery { PageIndex = pageIndex, PageSize = pageSize };
            var operationClaims = await Mediator.Send(query);
            return Ok(operationClaims);
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdOperationClaimQuery(id);
            var operationClaim = await Mediator.Send(query);
            return Ok(operationClaim);
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOperationClaimDto createOperationClaimDto)
        {
            var response = new CreateOperationClaimCommand(createOperationClaimDto);
            var result =await Mediator.Send(response);
            return Ok(result);
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateOperationClaimDto updateOperationClaimDto)
        {
            var response = new UpdateOperationClaimCommand(updateOperationClaimDto);
            var result =await Mediator.Send(response);
            return Ok(result);
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteOperationClaimDto updateOperationClaimDto)
        {
            var response = new DeleteOperationClaimCommand(updateOperationClaimDto);
            var result = await Mediator.Send(response);
            return Ok(result);
        }

        #endregion
    }
}

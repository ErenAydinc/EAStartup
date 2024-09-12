using Asp.Versioning;
using Core.EADomain.Domains;
using Core.EAInfrastructure;
using EAApplication.OperationClaims.Commands;
using EAApplication.OperationClaims.DTOs;
using EAApplication.OperationClaims.Queries;
using EAWebAPI.EACustomizing.EAController.v1;
using Microsoft.AspNetCore.Mvc;

namespace EAWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class OperationClaimsController : EAV1BaseController
    {
        #region Fields

        private readonly DynamicTranslationService _dynamicTranslationService;

        public OperationClaimsController(DynamicTranslationService dynamicTranslationService)
        {
            _dynamicTranslationService = dynamicTranslationService;
        }

        #endregion

        #region Ctor

        #endregion

        #region Methods
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> GetAllV1([FromHeader(Name = "Accept-Language")] string language,int pageIndex, int pageSize)
        {
            var query = new GetAllOperationClaimQuery { PageIndex = pageIndex, PageSize = pageSize };
            var operationClaims = await Mediator.Send(query);
            var translatedJson = await _dynamicTranslationService.TranslateAsync(operationClaims, language);
            return Ok(translatedJson);
        }
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> GetByIdV1([FromHeader(Name = "Accept-Language")] string language,int id)
        {
            var query = new GetByIdOperationClaimQuery(id);
            var operationClaim = await Mediator.Send(query);
            var translatedJson = await _dynamicTranslationService.TranslateAsync(operationClaim, language);
            return Ok(translatedJson);
        }
        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> CreateV1(CreateOperationClaimDto createOperationClaimDto)
        {
            var response = new CreateOperationClaimCommand(createOperationClaimDto);
            var result =await Mediator.Send(response);
            return Ok(result);
        }
        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> UpdateV1(UpdateOperationClaimDto updateOperationClaimDto)
        {
            var response = new UpdateOperationClaimCommand(updateOperationClaimDto);
            var result =await Mediator.Send(response);
            return Ok(result);
        }
        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> DeleteV1(DeleteOperationClaimDto updateOperationClaimDto)
        {
            var response = new DeleteOperationClaimCommand(updateOperationClaimDto);
            var result = await Mediator.Send(response);
            return Ok(result);
        }

        #endregion
    }
}

using Asp.Versioning;
using EAWebAPI.EACustomizing.EAAttribute;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAWebAPI.EACustomizing.EAController.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:2}/[controller]/[action]")]
    [ApiController]
    public class EAV2BaseController : ControllerBase
    {
        private IMediator _mediator;

        // IMediator Property olarak tanımlanır, lazy loading yapılır.
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}

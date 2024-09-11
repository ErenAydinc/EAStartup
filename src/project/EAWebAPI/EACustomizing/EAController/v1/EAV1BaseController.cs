using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EAWebAPI.EACustomizing.EAController.v1
{
    [ApiController]
    //[Route("api/[controller]/[action]")]
    public class EAV1BaseController : ControllerBase
    {
        private IMediator _mediator;

        // IMediator Property olarak tanımlanır, lazy loading yapılır.
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}

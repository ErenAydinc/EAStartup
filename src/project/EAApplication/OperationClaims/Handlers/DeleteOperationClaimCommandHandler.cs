using AutoMapper;
using EAApplication.OperationClaims.Commands;
using EAApplication.OperationClaims.DTOs;
using EAApplication.UserOperationClaims.DTOs;
using EASecurity.Authorization;
using EAService.OperationClaims;
using MediatR;
namespace EAApplication.OperationClaims.Handlers
{
    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeleteOperationClaimDto>
    {
        private readonly IOperationClaimService _operationClaimService;
        private readonly IMapper _mapper;

        public DeleteOperationClaimCommandHandler(IOperationClaimService operationClaimService, IMapper mapper)
        {
            _operationClaimService = operationClaimService;
            _mapper = mapper;
        }

        public async Task<DeleteOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request.DeleteOperationClaimDto);
            var response = await _operationClaimService.Delete(operationClaim.Id);
            DeleteOperationClaimDto deleteOperationClaimDto = _mapper.Map<DeleteOperationClaimDto>(response);
            return deleteOperationClaimDto;
        }
    }
}

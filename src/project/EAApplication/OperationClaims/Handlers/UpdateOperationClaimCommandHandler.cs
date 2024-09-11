using AutoMapper;
using Core.EADomain.Domains;
using EAApplication.OperationClaims.Commands;
using EAApplication.OperationClaims.DTOs;
using EAService.OperationClaims;
using MediatR;

namespace EAApplication.OperationClaims.Handlers
{
    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdateOperationClaimDto>
    {
        private readonly IOperationClaimService _operationClaimService;
        private readonly IMapper _mapper;

        public UpdateOperationClaimCommandHandler(IOperationClaimService operationClaimService, IMapper mapper)
        {
            _operationClaimService = operationClaimService;
            _mapper = mapper;
        }

        public async Task<UpdateOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request.UpdateOperationClaimDto);
            await _operationClaimService.Create(operationClaim);
            UpdateOperationClaimDto result = _mapper.Map<UpdateOperationClaimDto>(operationClaim);
            return result;
        }
    }
}

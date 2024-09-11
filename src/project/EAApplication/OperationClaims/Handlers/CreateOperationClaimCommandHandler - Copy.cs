using AutoMapper;
using Core.EADomain.Domains;
using EAApplication.OperationClaims.Commands;
using EAApplication.OperationClaims.DTOs;
using EAService.OperationClaims;
using MediatR;

namespace EAApplication.OperationClaims.Handlers
{
    public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreateOperationClaimDto>
    {
        private readonly IOperationClaimService _operationClaimService;
        private readonly IMapper _mapper;

        public CreateOperationClaimCommandHandler(IOperationClaimService operationClaimService, IMapper mapper)
        {
            _operationClaimService = operationClaimService;
            _mapper = mapper;
        }

        public async Task<CreateOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request.CreateOperationClaimDto);
            await _operationClaimService.Create(operationClaim);
            CreateOperationClaimDto result = _mapper.Map<CreateOperationClaimDto>(operationClaim);
            return result;
        }
    }
}

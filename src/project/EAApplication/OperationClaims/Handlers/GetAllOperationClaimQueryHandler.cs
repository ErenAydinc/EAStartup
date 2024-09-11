using AutoMapper;
using Core.EADomain;
using EAApplication.OperationClaims.DTOs;
using EAApplication.OperationClaims.Queries;
using EAService.OperationClaims;
using MediatR;

namespace EAApplication.OperationClaims.Handlers
{
    public class GetAllOperationClaimQueryHandler : IRequestHandler<GetAllOperationClaimQuery, EAPaginatedList<OperationClaimDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOperationClaimService _operationClaimService;

        public GetAllOperationClaimQueryHandler(IMapper mapper, IOperationClaimService operationClaimService)
        {
            _mapper = mapper;
            _operationClaimService = operationClaimService;
        }

        public async Task<EAPaginatedList<OperationClaimDto>> Handle(GetAllOperationClaimQuery request, CancellationToken cancellationToken)
        {
            var operataionClaims = await _operationClaimService.GetAll(request.PageIndex, request.PageSize);
            EAPaginatedList<OperationClaimDto> getAllOperationClaims= _mapper.Map<EAPaginatedList<OperationClaimDto>>(operataionClaims);
            return getAllOperationClaims;
        }
    }
}

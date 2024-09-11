using AutoMapper;
using Core.EADomain;
using EAApplication.UserOperationClaims.DTOs;
using EAApplication.UserOperationClaims.Queries;
using EAService.UserOperationClaims;
using MediatR;

namespace EAApplication.UserOperationClaims.Handlers
{
    public class GetAllUserOperationClaimQueryHandler : IRequestHandler<GetAllUserOperationClaimQuery, EAPaginatedList<UserOperationClaimDto>>
    {
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IMapper _mapper;

        public GetAllUserOperationClaimQueryHandler(IUserOperationClaimService userOperationClaimService, IMapper mapper)
        {
            _userOperationClaimService = userOperationClaimService;
            _mapper = mapper;
        }

        public async Task<EAPaginatedList<UserOperationClaimDto>> Handle(GetAllUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            var userOperationClaims = await _userOperationClaimService.GetAll(pageIndex: request.PageIndex, pageSize: request.PageSize);
            var result = _mapper.Map<EAPaginatedList<UserOperationClaimDto>>(userOperationClaims);
            return result;
        }
    }
}

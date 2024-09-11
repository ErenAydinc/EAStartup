using AutoMapper;
using EAApplication.UserOperationClaims.DTOs;
using EAApplication.UserOperationClaims.Queries;
using EAService.UserOperationClaims;
using MediatR;

namespace EAApplication.UserOperationClaims.Handlers
{
    public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, UserOperationClaimDto>
    {
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IMapper _mapper;

        public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimService userOperationClaimService, IMapper mapper)
        {
            _userOperationClaimService = userOperationClaimService;
            _mapper = mapper;
        }

        public async Task<UserOperationClaimDto> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            var userOperationClaim = await _userOperationClaimService.GetById(request.Id);
            var result = _mapper.Map<UserOperationClaimDto>(userOperationClaim);
            return result;
        }
    }
}

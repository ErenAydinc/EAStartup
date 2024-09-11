using AutoMapper;
using Core.EADomain.Domains;
using EAApplication.UserOperationClaims.Commands;
using EAApplication.UserOperationClaims.DTOs;
using EAService.UserOperationClaims;
using MediatR;

namespace EAApplication.UserOperationClaims.Handlers
{
    public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdateUserOperationClaimDto>
    {
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IMapper _mapper;

        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimService userOperationClaimService, IMapper mapper)
        {
            _userOperationClaimService = userOperationClaimService;
            _mapper = mapper;
        }

        public async Task<UpdateUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(request.UpdateUserOperationClaimDto);
            var response = await _userOperationClaimService.Update(userOperationClaim);
            var result = _mapper.Map<UpdateUserOperationClaimDto>(response);
            return result;
        }
    }
}

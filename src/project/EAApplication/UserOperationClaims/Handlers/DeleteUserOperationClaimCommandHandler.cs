using AutoMapper;
using Core.EADomain.Domains;
using EAApplication.UserOperationClaims.Commands;
using EAApplication.UserOperationClaims.DTOs;
using EAService.UserOperationClaims;
using MediatR;

namespace EAApplication.UserOperationClaims.Handlers
{
    public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeleteUserOperationClaimDto>
    {
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IMapper _mapper;

        public DeleteUserOperationClaimCommandHandler(IUserOperationClaimService userOperationClaimService, IMapper mapper)
        {
            _userOperationClaimService = userOperationClaimService;
            _mapper = mapper;
        }

        public async Task<DeleteUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(request.DeleteUserOperationClaimDto);
            var response = await _userOperationClaimService.Delete(userOperationClaim.Id);
            var result = _mapper.Map<DeleteUserOperationClaimDto>(response);
            return result;
        }
    }
}

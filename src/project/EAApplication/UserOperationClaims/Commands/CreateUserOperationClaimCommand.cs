using EAApplication.UserOperationClaims.DTOs;
using MediatR;

namespace EAApplication.UserOperationClaims.Commands
{
    public record CreateUserOperationClaimCommand(CreateUserOperationClaimDto CreateUserOperationClaimDto):IRequest<CreateUserOperationClaimDto>
    {
    }
}

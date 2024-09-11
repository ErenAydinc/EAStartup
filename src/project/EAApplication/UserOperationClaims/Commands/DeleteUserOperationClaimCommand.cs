using EAApplication.UserOperationClaims.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.UserOperationClaims.Commands
{
    public record DeleteUserOperationClaimCommand(DeleteUserOperationClaimDto DeleteUserOperationClaimDto):IRequest<DeleteUserOperationClaimDto>
    {
    }
}

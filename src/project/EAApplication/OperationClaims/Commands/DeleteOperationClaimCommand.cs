using EAApplication.OperationClaims.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.OperationClaims.Commands
{
    public record DeleteOperationClaimCommand(DeleteOperationClaimDto DeleteOperationClaimDto):IRequest<DeleteOperationClaimDto>
    {
    }
}

using EAApplication.OperationClaims.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.OperationClaims.Queries
{
    public record GetByIdOperationClaimQuery:IRequest<OperationClaimDto>
    {
        public int Id { get; set; }

        public GetByIdOperationClaimQuery(int id)
        {
            Id = id;
        }
    }
}

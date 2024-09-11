using EAApplication.UserOperationClaims.DTOs;
using EAApplication.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.UserOperationClaims.Queries
{
    public class GetByIdUserOperationClaimQuery:IRequest<UserOperationClaimDto>
    {
        public int Id { get; set; }
    }
}

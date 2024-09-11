using EAApplication.UserOperationClaims.DTOs;
using EAApplication.Users.DTOs;
using EACrossCuttingConcerns.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.UserOperationClaims.Queries
{
    public class GetAllUserOperationClaimQuery:IRequest<EAPaginatedList<UserOperationClaimDto>>
    {
        public UserOperationClaimDto UserOperationClaimDto { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

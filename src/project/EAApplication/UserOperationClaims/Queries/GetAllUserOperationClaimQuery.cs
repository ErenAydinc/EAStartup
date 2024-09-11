using Core.EADomain;
using EAApplication.UserOperationClaims.DTOs;
using MediatR;

namespace EAApplication.UserOperationClaims.Queries
{
    public class GetAllUserOperationClaimQuery:IRequest<EAPaginatedList<UserOperationClaimDto>>
    {
        public UserOperationClaimDto UserOperationClaimDto { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

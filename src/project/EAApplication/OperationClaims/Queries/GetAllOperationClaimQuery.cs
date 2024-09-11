using Core.EADomain;
using EAApplication.OperationClaims.DTOs;
using MediatR;

namespace EAApplication.OperationClaims.Queries
{
    public class GetAllOperationClaimQuery:IRequest<EAPaginatedList<OperationClaimDto>>
    {
        public GetAllOperationClaimQuery(OperationClaimDto operationClaimDto, int pageIndex, int pageSize)
        {
            OperationClaimDto = operationClaimDto;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public GetAllOperationClaimQuery()
        {
            
        }

        public OperationClaimDto OperationClaimDto { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

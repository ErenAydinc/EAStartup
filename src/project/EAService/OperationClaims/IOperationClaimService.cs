using Core.EADomain;
using Core.EADomain.Domains;

namespace EAService.OperationClaims
{
    public interface IOperationClaimService
    {
        Task<OperationClaim> Create(OperationClaim operationClaim);
        Task<OperationClaim> Update(OperationClaim operationClaim);
        Task<OperationClaim> Delete(int id);
        Task<OperationClaim?> GetById(int id);
        Task<OperationClaim?> GetByName(string name);
        Task<IEAPaginatedList<OperationClaim>> GetAll(int pageIndex, int pageSize);
    }
}

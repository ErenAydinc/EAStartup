using EARepository.Abstractions;
using EASecurity.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EAService.UserOperationClaims
{
    public interface IUserOperationClaimService
    {
        Task<IEAPaginatedList<UserOperationClaim>> GetAll(int pageIndex, int pageSize);
        Task<UserOperationClaim?> GetById(int id);
        Task<UserOperationClaim?> Get(Expression<Func<UserOperationClaim,bool>> predicate,bool? withDeleted=false);
        Task<UserOperationClaim?> GetByUserId(int userId);
        Task<UserOperationClaim> Create(UserOperationClaim userOperationClaim);
        Task<UserOperationClaim> Update(UserOperationClaim userOperationClaim);
        Task<UserOperationClaim> Delete(int userOperationClaimId);
        Task<List<int>> DeleteRangeByUserId(int userId);
    }
}

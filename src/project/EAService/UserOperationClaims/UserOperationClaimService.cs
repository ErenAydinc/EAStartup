using Core.EADomain;
using Core.EADomain.Domains;
using EAInfrastructure;
using System.Linq.Expressions;

namespace EAService.UserOperationClaims
{
    public class UserOperationClaimService : IUserOperationClaimService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Ctor
        public UserOperationClaimService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public async Task<UserOperationClaim> Create(UserOperationClaim userOperationClaim)
        {
            await _unitOfWork.GetRepository<UserOperationClaim>().Create(userOperationClaim);
            await _unitOfWork.SaveChangesAsync();
            return userOperationClaim;
        }

        public async Task<UserOperationClaim> Delete(int userOperationClaimId)
        {
            var userOperationClaim = await _unitOfWork.GetRepository<UserOperationClaim>().GetById(userOperationClaimId);
            await _unitOfWork.GetRepository<UserOperationClaim>().SoftDelete(userOperationClaim);
            await _unitOfWork.SaveChangesAsync();
            return userOperationClaim;
            
        }

        public async Task<List<int>> DeleteRangeByUserId(int userId)
        {
            var ids = (await _unitOfWork.GetRepository<UserOperationClaim>().GetAll(x => x.UserId == userId)).Select(x=>x.Id);
            await _unitOfWork.GetRepository<UserOperationClaim>().SoftDeleteRange(ids.ToList());
            await _unitOfWork.SaveChangesAsync();
            return ids.ToList();
        }

        public async Task<IEAPaginatedList<UserOperationClaim>> GetAll(int pageIndex, int pageSize)
        {
            return await _unitOfWork.GetRepository<UserOperationClaim>().GetAllPaginate(pageIndex: pageIndex, pageSize: pageSize);
        }

        public async Task<UserOperationClaim?> GetById(int id)
        {
            return await _unitOfWork.GetRepository<UserOperationClaim>().GetById(id);
        }

        public async Task<UserOperationClaim?> Get(Expression<Func<UserOperationClaim,bool>> predicate,bool? withDeleted=false)
        {
            return await _unitOfWork.GetRepository<UserOperationClaim>().Get(predicate,withDeleted);
        }

        public async Task<UserOperationClaim?> GetByUserId(int userId)
        {
            return await _unitOfWork.GetRepository<UserOperationClaim>().Get(x => x.UserId == userId);
        }

        public async Task<UserOperationClaim> Update(UserOperationClaim userOperationClaim)
        {
            await _unitOfWork.GetRepository<UserOperationClaim>().Update(userOperationClaim);
            await _unitOfWork.SaveChangesAsync();
            return userOperationClaim;
        }
    }
}

using Core.EADomain;
using Core.EADomain.Domains;
using Core.EAInfrastructure;

namespace EAService.OperationClaims
{
    public class OperationClaimService : IOperationClaimService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Ctor
        public OperationClaimService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        public async Task<OperationClaim> Create(OperationClaim operationClaim)
        {
            await _unitOfWork.GetRepository<OperationClaim>().Create(operationClaim);
            await _unitOfWork.SaveChangesAsync();
            return operationClaim;
        }

        public async Task<OperationClaim> Delete(int id)
        {
            var operationClaim = await _unitOfWork.GetRepository<OperationClaim>().GetById(id);
            await _unitOfWork.GetRepository<OperationClaim>().SoftDelete(id);
            await _unitOfWork.SaveChangesAsync();
            return operationClaim;
        }

        public async Task<IEAPaginatedList<OperationClaim>> GetAll(int pageIndex, int pageSize)
        {
            return await _unitOfWork.GetRepository<OperationClaim>().GetAllPaginate(pageIndex: pageIndex, pageSize: pageSize);
        }

        public async Task<OperationClaim?> GetById(int id)
        {
            return await _unitOfWork.GetRepository<OperationClaim>().GetById(id);
        }

        public async Task<OperationClaim?> GetByName(string name)
        {
            return await _unitOfWork.GetRepository<OperationClaim>().Get(x => x.Name == name);
        }

        public async Task<OperationClaim> Update(OperationClaim operationClaim)
        {
            await _unitOfWork.GetRepository<OperationClaim>().Update(operationClaim);
            await _unitOfWork.SaveChangesAsync();
            return operationClaim;
        }
    }
}

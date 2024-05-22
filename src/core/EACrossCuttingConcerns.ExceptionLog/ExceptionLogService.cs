using EARepository.Abstractions;

namespace EACrossCuttingConcerns.ExceptionLogging
{
    public class ExceptionLogService : IExceptionLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExceptionLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ExceptionLog> Add(ExceptionLog exceptionLog)
        {
            await _unitOfWork.GetRepository<ExceptionLog>().AddAsync(exceptionLog);
            await _unitOfWork.SaveChangesAsync();
            return exceptionLog;
        }

        public Task<ExceptionLog> GetList(ExceptionLog exceptionLog)
        {
            throw new NotImplementedException();
        }
    }
}

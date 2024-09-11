using EARepository.Abstractions;

namespace EACQRS.Pipelines.MediatrRequestLogging
{
    public class LoggeableRequestService : ILoggeableRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoggeableRequestService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Add(LoggeableRequest loggeableRequest)
        {
            await _unitOfWork.GetRepository<LoggeableRequest>().Create(loggeableRequest);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

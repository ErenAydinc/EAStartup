using EACrossCuttingConcerns.ExceptionLogging;
using EARepository.Abstractions;

namespace EACrossCuttingConcerns.ExceptionLogging
{
    public interface IExceptionLogService
    {
        Task<ExceptionLog> Add(ExceptionLog exceptionLog);
        Task<ExceptionLog> GetList(ExceptionLog exceptionLog);
    }
}

namespace Core.EACrossCuttingConcerns.ExceptionLogging
{
    public interface IExceptionLogService
    {
        Task<ExceptionLog> Add(ExceptionLog exceptionLog);
        Task<ExceptionLog> GetList(ExceptionLog exceptionLog);
    }
}

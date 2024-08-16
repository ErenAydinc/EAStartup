using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EACQRS.Pipelines.MediatrRequestLogging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ILoggeableRequest
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILoggeableRequestService _loggeableRequestService;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger, IHttpContextAccessor httpContextAccessor, ILoggeableRequestService loggeableRequestService)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _loggeableRequestService = loggeableRequestService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            string? userId = _httpContextAccessor.HttpContext?.Items["UserId"]?.ToString();
            var timestamp = DateTime.Now;
            int intUserId = userId == null ? 0 : Convert.ToInt32(userId);

            LoggeableRequest loggeableRequest = new(commandName: requestName, userId: intUserId)
            {
                CommandName = requestName,
                UserId = intUserId
            };

            await _loggeableRequestService.Add(loggeableRequest);
            //_logger.LogInformation("Handling request {RequestName} at {Timestamp} by user {UserId}", requestName, timestamp, userId);

            //_logger.LogInformation("Handled request {RequestName}", requestName);

            
            return await next();
        }
    }
}

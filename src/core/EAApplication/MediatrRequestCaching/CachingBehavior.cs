using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Core.EAInfrastructure.Pipelines.MediatrRequestCaching
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICachableRequest, IRequest<TResponse>
    {
        private readonly IMemoryCache _cache;

        public CachingBehavior(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_cache.TryGetValue(request.CacheKey, out TResponse cachedResponse))
            {
                return cachedResponse;
            }

            TResponse response = await next();

            _cache.Set(request.CacheKey, response, request.CacheDuration);

            return response;
        }
    }
}

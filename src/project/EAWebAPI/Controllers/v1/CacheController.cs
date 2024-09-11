using Asp.Versioning;
using EAWebAPI.EACustomizing.EAController.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EAWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class CacheController : EAV1BaseController
    {
        private readonly IMemoryCache _memoryCache;

        public CacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        [MapToApiVersion("1.0")]
        [HttpDelete]
        public IActionResult RemoveCacheV1(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
            return NoContent();
        }
    }
}

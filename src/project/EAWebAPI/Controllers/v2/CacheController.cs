using Asp.Versioning;
using EAWebAPI.EACustomizing.EAController.v2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EAWebAPI.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class CacheController : EAV2BaseController
    {
        private readonly IMemoryCache _memoryCache;

        public CacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [MapToApiVersion("2.0")]
        [HttpDelete]
        public IActionResult RemoveCache(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
            return NoContent();
        }
    }
}

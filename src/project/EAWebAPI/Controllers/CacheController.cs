using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EAWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public CacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpDelete]
        public IActionResult RemoveCache(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
            return NoContent();
        }
    }
}

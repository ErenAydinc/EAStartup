using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EACQRS.Pipelines.MediatrRequestCaching
{
    public interface ICachableRequest
    {
        string CacheKey { get; }
        TimeSpan CacheDuration { get; }
    }
}

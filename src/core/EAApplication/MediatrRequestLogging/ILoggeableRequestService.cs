using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EAApplication.MediatrRequestLogging
{
    public interface ILoggeableRequestService
    {
        Task Add(LoggeableRequest loggeableRequest);
    }
}

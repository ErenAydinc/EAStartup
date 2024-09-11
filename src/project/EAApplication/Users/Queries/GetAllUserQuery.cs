using Core.EAApplication.MediatrRequestLogging;
using Core.EADomain;
using Core.EAInfrastructure.Pipelines.MediatrRequestCaching;
using EAApplication.Users.DTOs;
using MediatR;

namespace EAApplication.Users.Queries
{
    public class GetAllUserQuery : IRequest<IEAPaginatedList<UserDto>>,ICachableRequest,ILoggeableRequest
    {
        public UserDto UserDto { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string CacheKey => $"GetAllUsers";
        public TimeSpan CacheDuration => TimeSpan.FromMinutes(1);
    }
}

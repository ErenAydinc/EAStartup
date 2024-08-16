using EAApplication.Users.DTOs;
using EACQRS.Pipelines.MediatrRequestCaching;
using EACrossCuttingConcerns.Generic;
using EARepository.Abstractions;
using MediatR;

namespace EAApplication.Users.Queries
{
    public class GetAllUserQuery : IRequest<IEAPaginatedList<UserDto>>,ICachableRequest
    {
        public UserDto UserDto { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string CacheKey => $"GetAllUsers";
        public TimeSpan CacheDuration => TimeSpan.FromMinutes(1);
    }
}

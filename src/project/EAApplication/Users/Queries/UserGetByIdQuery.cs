using EAApplication.Users.DTOs;
using EACQRS.Pipelines.MediatrRequestCaching;
using MediatR;

namespace EAApplication.Users.Queries
{
    public class UserGetByIdQuery : IRequest<UserDto>, ICachableRequest
    {
        public int Id { get; set; }
        public string CacheKey => $"GetByIdUser"+Id;

        public TimeSpan CacheDuration => TimeSpan.FromMinutes(1);
    }
}

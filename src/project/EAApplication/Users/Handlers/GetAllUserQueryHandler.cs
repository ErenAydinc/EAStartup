using AutoMapper;
using Core.EADomain;
using EAApplication.Users.DTOs;
using EAApplication.Users.Queries;
using EAService.Users;
using MediatR;

namespace EAApplication.Users.Handlers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery,IEAPaginatedList<UserDto>>
    {
        //public int PageIndex { get; set; }
        //public int PageSize { get; set; }
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetAllUserQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<IEAPaginatedList<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userService.GetAll(request.PageIndex, request.PageSize);
            var userDto = _mapper.Map<EAPaginatedList<UserDto>>(userList);
            return userDto;
        }
    }
}

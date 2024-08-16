using AutoMapper;
using EAApplication.Users.DTOs;
using EAApplication.Users.Queries;
using EACrossCuttingConcerns.Generic;
using EARepository.Abstractions;
using EASecurity.Authorization;
using EAService.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

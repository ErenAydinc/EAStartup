using AutoMapper;
using EAApplication.Users.DTOs;
using EAApplication.Users.Queries;
using EAService.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.Users.Handlers
{
    public class UserGetByIdQueryHandler : IRequestHandler<GetByIdUserQuery, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserGetByIdQueryHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<UserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetById(request.Id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}

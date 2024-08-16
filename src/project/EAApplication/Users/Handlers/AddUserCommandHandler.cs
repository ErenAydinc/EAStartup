using AutoMapper;
using EAApplication.Users.Commands;
using EAApplication.Users.DTOs;
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
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, CreateUserDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<CreateUserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.createUserDto);
            var createUser = await _userService.Add(user);
            var result = _mapper.Map<CreateUserDto>(createUser);
            return result;
        }
    }
}

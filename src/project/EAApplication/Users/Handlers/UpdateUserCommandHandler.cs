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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.updateUserDto);
            var updateUser = await _userService.Update(user);
            var result = _mapper.Map<UpdateUserDto>(updateUser);
            return result;
        }
    }
}

using AutoMapper;
using Core.EADomain.Domains;
using EAApplication.Users.Commands;
using EAApplication.Users.DTOs;
using EAService.Users;
using MediatR;

namespace EAApplication.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.createUserDto);
            var createUser = await _userService.Create(user);
            var result = _mapper.Map<CreateUserDto>(createUser);
            return result;
        }
    }
}

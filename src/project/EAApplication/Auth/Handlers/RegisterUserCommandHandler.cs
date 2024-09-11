using AutoMapper;
using EAApplication.Auth.Commands;
using EAApplication.Auth.DTOs;
using EAApplication.Auth.Rules;
using EADomain;
using EAService.Users;
using MediatR;

namespace EAApplication.Auth.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AuthBusinessRules _userBusinessRules;
        public RegisterUserCommandHandler(IUserService userService, IMapper mapper, AuthBusinessRules userBusinessRules)
        {
            _userService = userService;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<RegisterDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.RegisterControl(request.RegisterDto.Email);
            RegisterUser registerUser = _mapper.Map<RegisterUser>(request.RegisterDto);
            var user = await _userService.Register(registerUser);
            return request.RegisterDto;
        }
    }
}

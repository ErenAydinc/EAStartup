using AutoMapper;
using EAApplication.Auth.Commands;
using EAApplication.Auth.DTOs;
using EAApplication.Auth.Rules;
using EADomain;
using EAService.Users;
using MediatR;

namespace EAApplication.Auth.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,LoginUserDto>
    {
        private readonly IUserService _userService;
        private readonly AuthBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;
        public LoginUserCommandHandler(IUserService userService, IMapper mapper, AuthBusinessRules userBusinessRules)
        {
            _userService = userService;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<LoginUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRules.LoginControl(request.LoginUserDto.Email,request.LoginUserDto.Password);
            LoginUser loginUser = _mapper.Map<LoginUser>(request.LoginUserDto);
            var user = await _userService.Login(loginUser);
            LoginUserDto loginUserDto = _mapper.Map<LoginUserDto>(user);
            return loginUserDto;
        }
    }
}

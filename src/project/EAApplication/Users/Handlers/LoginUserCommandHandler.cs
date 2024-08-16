using AutoMapper;
using EAApplication.Users.Commands;
using EAApplication.Users.DTOs;
using EAApplication.Users.Rules;
using EACQRS.Pipelines.MediatrRequestLogging;
using EADomain;
using EAService.Users;
using MediatR;

namespace EAApplication.Users.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,LoginUserDto>
    {
        private readonly IUserService _userService;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;
        public LoginUserCommandHandler(IUserService userService, IMapper mapper, UserBusinessRules userBusinessRules)
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

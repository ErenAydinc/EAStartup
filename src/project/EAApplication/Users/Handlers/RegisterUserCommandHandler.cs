using AutoMapper;
using EAApplication.Users.Commands;
using EAApplication.Users.DTOs;
using EAApplication.Users.Rules;
using EADomain;
using EAService.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.Users.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;
        public RegisterUserCommandHandler(IUserService userService, IMapper mapper, UserBusinessRules userBusinessRules)
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

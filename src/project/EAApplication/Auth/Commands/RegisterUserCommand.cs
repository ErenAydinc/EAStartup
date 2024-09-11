using EAApplication.Auth.DTOs;
using EAApplication.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.Auth.Commands
{
    public record RegisterUserCommand(RegisterDto RegisterDto):IRequest<RegisterDto>;
}

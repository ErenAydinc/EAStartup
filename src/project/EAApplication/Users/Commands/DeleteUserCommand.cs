using EAApplication.Users.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.Users.Commands
{
    public record DeleteUserCommand(DeleteUserDto deleteUserDto):IRequest<DeleteUserDto>;
}

using EAApplication.Users.DTOs;
using MediatR;

namespace EAApplication.Users.Commands
{
    public record UpdateUserCommand(UpdateUserDto updateUserDto):IRequest<UpdateUserDto>;
}

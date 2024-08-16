using EAApplication.Users.DTOs;
using MediatR;

namespace EAApplication.Users.Commands
{
    public record AddUserCommand(CreateUserDto createUserDto):IRequest<CreateUserDto>;
}

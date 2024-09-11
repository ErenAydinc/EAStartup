using EAApplication.Users.DTOs;
using MediatR;

namespace EAApplication.Users.Commands
{
    public record CreateUserCommand(CreateUserDto createUserDto):IRequest<CreateUserDto>;
}

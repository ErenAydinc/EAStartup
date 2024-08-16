using EAApplication.Users.DTOs;
using EACQRS.Pipelines.MediatrRequestLogging;
using MediatR;

namespace EAApplication.Users.Commands
{
    public record LoginUserCommand(LoginUserDto LoginUserDto) : IRequest<LoginUserDto>,ILoggeableRequest;
}

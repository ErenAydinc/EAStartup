using EAApplication.Auth.DTOs;
using EACQRS.Pipelines.MediatrRequestLogging;
using MediatR;

namespace EAApplication.Auth.Commands
{
    public record LoginUserCommand(LoginUserDto LoginUserDto) : IRequest<LoginUserDto>, ILoggeableRequest;
}

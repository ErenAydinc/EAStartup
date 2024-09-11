using Core.EAApplication.MediatrRequestLogging;
using EAApplication.Auth.DTOs;
using MediatR;

namespace EAApplication.Auth.Commands
{
    public record LoginUserCommand(LoginUserDto LoginUserDto) : IRequest<LoginUserDto>, ILoggeableRequest;
}

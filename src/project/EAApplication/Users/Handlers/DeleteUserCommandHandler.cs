using AutoMapper;
using Core.EADomain.Domains;
using EAApplication.Users.Commands;
using EAApplication.Users.DTOs;
using EAService.Users;
using MediatR;

namespace EAApplication.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<DeleteUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.deleteUserDto);
            var getUser = await _userService.GetById(request.deleteUserDto.Id);
            await _userService.Delete(user.Id);
            var deleteUserDto = _mapper.Map<DeleteUserDto>(getUser);
            return deleteUserDto;
        }
    }
}

using AutoMapper;
using EAApplication.UserOperationClaims.Commands;
using EAApplication.UserOperationClaims.DTOs;
using EAApplication.UserOperationClaims.Rules;
using EASecurity.Authorization;
using EAService.UserOperationClaims;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.UserOperationClaims.Handlers
{
    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreateUserOperationClaimDto>
    {
        private readonly UserOperationClaimBusinessRules _businessRules;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IMapper _mapper;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimService userOperationClaimService, IMapper mapper, UserOperationClaimBusinessRules businessRules)
        {
            _userOperationClaimService = userOperationClaimService;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreateUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(request.CreateUserOperationClaimDto);
            await _businessRules.OperationClaimAndUserControl(userOperationClaim);
            var response = await _userOperationClaimService.Create(userOperationClaim);
            var result = _mapper.Map<CreateUserOperationClaimDto>(response);
            return result;
        }
    }
}

using AutoMapper;
using EAApplication.OperationClaims.DTOs;
using EAApplication.OperationClaims.Queries;
using EAService.OperationClaims;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.OperationClaims.Handlers
{
    public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, OperationClaimDto>
    {
        private readonly IMapper _mapper;
        private readonly IOperationClaimService _operationClaimService;

        public GetByIdOperationClaimQueryHandler(IMapper mapper, IOperationClaimService operationClaimService)
        {
            _mapper = mapper;
            _operationClaimService = operationClaimService;
        }

        public async Task<OperationClaimDto> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimService.GetById(request.Id);
            OperationClaimDto operationClaimDto = _mapper.Map<OperationClaimDto>(operationClaim);
            return operationClaimDto;
        }
    }
}

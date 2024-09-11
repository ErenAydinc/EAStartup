using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.UserOperationClaims.DTOs
{
    public class CreateUserOperationClaimDto
    {
        public CreateUserOperationClaimDto()
        {
            
        }
        public CreateUserOperationClaimDto(int userId, int operationClaimId)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }

        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}

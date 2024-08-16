using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASecurity.Authorization
{
    public class UserOperationClaim:EAEntity
    {
        public UserOperationClaim()
        {
            
        }
        public UserOperationClaim(int userId, int operationClaimId)
        {
            UserId = userId;
            OperationClaimId = operationClaimId;
        }

        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}

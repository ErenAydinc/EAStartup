using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.OperationClaims.DTOs
{
    public class DeleteOperationClaimDto
    {
        public int Id { get; set; }

        public DeleteOperationClaimDto(int id)
        {
            Id = id;
        }
        public DeleteOperationClaimDto()
        {
        }
    }
}

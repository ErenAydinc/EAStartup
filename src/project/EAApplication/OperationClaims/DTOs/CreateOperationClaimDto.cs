using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.OperationClaims.DTOs
{
    public class CreateOperationClaimDto
    {
        public CreateOperationClaimDto(string name)
        {
            Name = name;
        }
        public CreateOperationClaimDto()
        {
                
        }
        public string Name { get; set; }
    }
}

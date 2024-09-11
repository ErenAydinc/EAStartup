using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.OperationClaims.DTOs
{
    public class UpdateOperationClaimDto
    {
        public UpdateOperationClaimDto(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public UpdateOperationClaimDto()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASecurity.Authorization
{
    public class OperationClaim:EAEntity
    {
        public OperationClaim()
        {

        }

        public OperationClaim(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}

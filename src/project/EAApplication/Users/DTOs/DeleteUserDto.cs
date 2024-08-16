using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.Users.DTOs
{
    public class DeleteUserDto:EADTO
    {
        public DeleteUserDto()
        {
            
        }

        public DeleteUserDto(string? email)
        {
            Email = email;
        }

        public string? Email { get; set; }
    }
}

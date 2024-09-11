using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.Users.DTOs
{
    public class DeleteUserDto
    {
        public DeleteUserDto()
        {
            
        }

        public DeleteUserDto(string? email, int id)
        {
            Email = email;
            Id = id;
        }
        public int Id { get; set; }
        public string? Email { get; set; }
    }
}

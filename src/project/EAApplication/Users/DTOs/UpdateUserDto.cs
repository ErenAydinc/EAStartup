using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.Users.DTOs
{
    public class UpdateUserDto:EADTO
    {
        public UpdateUserDto()
        {
            
        }
        public UpdateUserDto(string? firstName, string? lastName, string? email, string? password, string? ısActive)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            IsActive = ısActive;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? IsActive { get; set; }
    }
}

using EARepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.Users.DTOs
{
    public class UserDto:EADTO
    {
        public UserDto()
        {

        }
        public UserDto(string? firstName, string? lastName, string? email, bool? isActive, string? token, string? password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsActive = isActive;
            Token = token;
            Password = password;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public string? Token { get; set; }
        public string? Password { get; set; }
    }
}

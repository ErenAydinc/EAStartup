using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAApplication.Auth.DTOs
{
    public class LoginUserDto(string email, string password, string? token)
    {
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
        public string? Token { get; set; } = token;
    }
}

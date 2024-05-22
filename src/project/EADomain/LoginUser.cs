using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADomain
{
    public class LoginUser(string email, string password)
    {
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
    }
}

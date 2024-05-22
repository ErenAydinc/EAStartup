using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EADomain
{
    public class RegisterUser(string firstName, string lastName, string email, string password, List<string>? roles)
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
        public List<string>? Roles { get; set; }=roles;
    }
}

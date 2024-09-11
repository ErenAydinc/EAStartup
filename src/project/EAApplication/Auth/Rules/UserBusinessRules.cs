using Core.EADomain.Domains;
using EAService.Users;
using Isopoh.Cryptography.Argon2;

namespace EAApplication.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserService _userService;
        public AuthBusinessRules(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> LoginControl(string email, string password)
        {
            var user = await _userService.GetByEmail(email);
            if (user is null)
            {
                throw new Exception("User not found");
            }
            else if (Argon2.Verify(user.Password, password) == false)
            {
                throw new Exception("User password is wrong");
            }
            else
            {
                return user;
            }
        }

        public async Task<User> RegisterControl(string email)
        {
            var user = await _userService.GetByEmail(email);
            if (user is not null)
            {
                throw new Exception("User already exist");
            }
            else
            {
                return null;
            }
        }
    }
}

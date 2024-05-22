using EADomain;
using EARepository.Abstractions;
using EASecurity.Authorization;
using Isopoh.Cryptography.Argon2;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EAService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly HashingAndGenerateToken _hashingAndGenerateToken;
        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration, HashingAndGenerateToken hashingAndGenerateToken)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _hashingAndGenerateToken = hashingAndGenerateToken;
        }

        public async Task<User> Login(User loginUser)
        {
            User? user = await _unitOfWork.GetRepository<User>().Get(x => x.Email == loginUser.Email);
            var token = _hashingAndGenerateToken.GenerateToken(user, loginUser.Password);
            user.IsActive= true;
            user.Token = token;
            return user;
        }

        public async Task<User> Register(User registerUser)
        {
            registerUser.Password = _hashingAndGenerateToken.HashPassword(registerUser.Password);
            await _unitOfWork.GetRepository<User>().AddAsync(registerUser);
            await _unitOfWork.SaveChangesAsync();
            return registerUser;
        }
    }
}

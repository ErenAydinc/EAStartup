using EADomain;
using EARepository.Abstractions;
using EASecurity.Authorization;
using Isopoh.Cryptography.Argon2;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EAService.Users
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

        public async Task<User> Login(LoginUser loginUser)
        {
            User? user = await _unitOfWork.GetRepository<User>().Get(x => x.Email == loginUser.Email);

            List<int> claims = (await _unitOfWork.GetRepository<UserOperationClaim>().GetAll(x => x.UserId == user.Id)).Select(x => x.OperationClaimId).ToList();
            
            List<string> roles = new List<string>();
            
            foreach (var claim in claims)
            {
                var userRole = (await _unitOfWork.GetRepository<OperationClaim>().Get(x => x.Id == claim)).Name;
                roles.Add(userRole);
            }
            
            var token = _hashingAndGenerateToken.GenerateToken(user,roles, loginUser.Password);
            if (token is null)
            {
                user = null;
                return user;
            }
            user.IsActive = true;
            user.Token = token;
            return user;
        }

        public async Task<User> Register(RegisterUser registerUser)
        {
            registerUser.Password = _hashingAndGenerateToken.HashPassword(registerUser.Password);
            User addUser = new User
            {
                Email = registerUser.Email,
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Password = registerUser.Password,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                DeletedDate = null,
                UpdatedDate = null,
                Token= null,
            };
            await _unitOfWork.GetRepository<User>().Create(addUser);
            await _unitOfWork.SaveChangesAsync();
            return addUser;
        }

        public async Task<User> Create(User user)
        {
            user.Password = _hashingAndGenerateToken.HashPassword(user.Password);
            user.CreatedDate = DateTime.UtcNow;
            user.IsActive = true;
            await _unitOfWork.GetRepository<User>().Create(user);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            if (user.Password is not null)
            {
                user.Password = _hashingAndGenerateToken.HashPassword(user.Password);
            }
            await _unitOfWork.GetRepository<User>().Update(user);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.GetRepository<User>().SoftDelete(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _unitOfWork.GetRepository<User>().Get(x=>x.Email == email);
            return user;
        }
        public async Task<IEAPaginatedList<User>> GetAll(int pageIndex,int pageSize)
        {
            var user = await _unitOfWork.GetRepository<User>().GetAllPaginate(pageIndex:pageIndex,pageSize:pageSize);
            return user;
        }

        public async Task<User> GetById(int id)
        {
            return await _unitOfWork.GetRepository<User>().GetById(id);
        }
    }
}

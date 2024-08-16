using EADomain;
using EARepository.Abstractions;
using EASecurity.Authorization;

namespace EAService.Users
{
    public interface IUserService
    {
        Task<User> Login(LoginUser loginUser);
        Task<User> Register(RegisterUser registerUser);
        Task<User> GetByEmail(string email);
        Task<IEAPaginatedList<User>> GetAll(int pageIndex,int pageSize);
        Task<User> GetById(int id);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task Delete(int id);
    }
}

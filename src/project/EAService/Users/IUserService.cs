using Core.EADomain;
using Core.EADomain.Domains;
using EADomain;

namespace EAService.Users
{
    public interface IUserService
    {
        Task<User> Login(LoginUser loginUser);
        Task<User> Register(RegisterUser registerUser);
        Task<User> GetByEmail(string email);
        Task<IEAPaginatedList<User>> GetAll(int pageIndex,int pageSize);
        Task<User> GetById(int id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task Delete(int id);
    }
}

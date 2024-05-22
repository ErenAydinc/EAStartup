using EADomain;
using EASecurity.Authorization;

namespace EAService
{
    public interface IUserService
    {
        Task<User> Login(User loginUser);
        Task<User> Register(User registerUser);
    }
}

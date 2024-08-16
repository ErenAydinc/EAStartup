using EADataBase;
using EARepository.Abstractions;
using EARepository.Generic;
using EASecurity.Authorization;
using EAService.Users;
using Microsoft.Extensions.DependencyInjection;

namespace EAService
{
    public static class ServicesApplicationServiceRegistration
    {
        public static IServiceCollection AddServicesApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<HashingAndGenerateToken>();
            return services;
        }
    }
}

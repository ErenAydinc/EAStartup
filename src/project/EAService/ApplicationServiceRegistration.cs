using EADataBase;
using EARepository.Abstractions;
using EARepository.Generic;
using EASecurity.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAService
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<HashingAndGenerateToken>();
            return services;
        }
    }
}

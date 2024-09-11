using EADataBase;
using EAInfrastructure;
using EAService.OperationClaims;
using EAService.UserOperationClaims;
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
            services.AddScoped<IUserOperationClaimService, UserOperationClaimService>();
            services.AddScoped<IOperationClaimService, OperationClaimService>();
            return services;
        }
    }
}

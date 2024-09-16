using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EAInfrastructure
{
    public static class ServicesApplicationServiceRegistration
    {
        public static IServiceCollection AddCoreServicesApplicationServices(this IServiceCollection services)
        {

            // HttpClient ve TranslationService ekleme
            services.AddScoped<GoogleDynamicTranslationService>();
            //services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
            services.AddSingleton<HashingAndGenerateToken>();
            return services;
        }
    }
}

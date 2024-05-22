using EARepository.Abstractions;
using EARepository.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace EACrossCuttingConcerns.ExceptionLogging
{
    public static class ExceptionLoggingServiceRegistration
    {
        public static IServiceCollection AddExceptionLoggingServices(this IServiceCollection services)
        {
            services.AddScoped<IExceptionLogService, ExceptionLogService>();
            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace Core.EACrossCuttingConcerns.ExceptionLogging
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

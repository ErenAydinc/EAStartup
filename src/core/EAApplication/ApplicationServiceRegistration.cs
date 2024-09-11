using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using Core.EAApplication.Validations;
using Core.EAApplication.MediatrRequestLogging;
using Core.EAInfrastructure.Pipelines.MediatrRequestCaching;
namespace Core.EAApplication
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddCoreApplicationServices(
       this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            });
            services.AddMemoryCache();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            return services;
        }
    }
}

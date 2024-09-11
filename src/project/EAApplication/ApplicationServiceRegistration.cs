using EAApplication.Auth.Rules;
using EAApplication.UserOperationClaims.Rules;
using EAApplication.Users.Rules;
using EACQRS.Pipelines;
using EACQRS.Pipelines.MediatrRequestCaching;
using EACQRS.Pipelines.MediatrRequestLogging;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EAApplication
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(
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
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<UserOperationClaimBusinessRules>();
            return services;
        }
    }
}

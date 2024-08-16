using EACQRS.Pipelines.MediatrRequestLogging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EACQRS.Pipelines
{
    public static class ExceptionRequestPipelineServiceRegistration
    {
        public static IServiceCollection AddExceptionRequestPipelineServices(this IServiceCollection services)
        {
            services.AddScoped<ILoggeableRequestService, LoggeableRequestService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}

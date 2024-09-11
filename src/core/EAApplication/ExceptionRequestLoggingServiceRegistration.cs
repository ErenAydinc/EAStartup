using Core.EAApplication.MediatrRequestLogging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Core.EAApplication
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

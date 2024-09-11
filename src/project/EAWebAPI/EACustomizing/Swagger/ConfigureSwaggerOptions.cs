using Asp.Versioning.ApiExplorer;
using EAWebAPI.EACustomizing.OperationFilters;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;

namespace EAWebAPI.EACustomizing.Swagger
{
    public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IConfiguration configuration) : IConfigureNamedOptions<SwaggerGenOptions>
    {
        //3
        public void Configure(string? name, SwaggerGenOptions options)
        {
            options.OperationFilter<SwaggerJsonIgnoreFilter>();;
            var folder = Environment.CurrentDirectory.Replace(Assembly.GetExecutingAssembly().GetName().Name!, "");
            if (!string.IsNullOrEmpty(folder))
                foreach (var nm in Directory.GetFiles(folder, "*.xml", SearchOption.AllDirectories))
                    options.IncludeXmlComments(filePath: nm);

            //options.e();

            Configure(options);
        }

        //4
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        //5
        private OpenApiInfo CreateVersionInfo(ApiVersionDescription desc)
        {
            var section = configuration.GetSection("SwaggerSettings");
            var apiName = section.GetValue<string>("Name");
            var apiDesc = section.GetValue<string>("Description");
            var teamName = section.GetValue<string>("TeamName");
            var teamEmail = section.GetValue<string>("TeamEmail");
            var termsOfService = section.GetValue<string>("TermsOfService");

            var info = new OpenApiInfo
            {
                Title = apiName,
                Version = desc.ApiVersion.ToString(),
                Description = apiDesc,
                Contact = new OpenApiContact
                {
                    Name = teamName,
                    Email = teamEmail
                },
                TermsOfService = new Uri(string.IsNullOrEmpty(termsOfService) ? "https://www.hepsiburada.com/" : termsOfService)
            };

            if (desc.IsDeprecated)
            {
                info.Description += " This API version has been deprecated. Please use one of the new APIs available from the explorer.";
            }

            return info;
        }
    }
}

using Asp.Versioning.ApiExplorer;
using Asp.Versioning;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using EAWebAPI.EACustomizing.OperationFilters;
namespace EAWebAPI.EACustomizing.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerWithVersion(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<DeprecatedOperationFilter>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter Bearer <YourToken>"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme {
            Reference= new OpenApiReference {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        },
         new string[] {}
        }

    });
            });
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader
                                       .Combine(new UrlSegmentApiVersionReader(),
                                                new QueryStringApiVersionReader(),
                                                new HeaderApiVersionReader("my-api-version-key"),
                                                new MediaTypeApiVersionReader("my-api-version-key"));
            }).AddApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }


        public static IApplicationBuilder UseSwaggerWithVersion(this IApplicationBuilder app)
        {
            var apiVersionDescriptionProvider = app.ApplicationServices
                                                   .GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                    options.SwaggerEndpoint(url: $"/swagger/{description.GroupName}/swagger.json",
                                           name: description.GroupName.ToUpperInvariant());

            });

            return app;
        }
    }
}

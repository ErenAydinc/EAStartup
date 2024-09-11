using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EAWebAPI.EACustomizing.OperationFilters
{
    public class DeprecatedOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.IsDeprecated())
            {
                operation.Summary += " [DEPRECATED]";  // Bu metodun deprecated olduğunu işaretler.
                operation.Description += " This API is deprecated and may be removed in future versions."; // Ek açıklama
            }
        }
    }
}

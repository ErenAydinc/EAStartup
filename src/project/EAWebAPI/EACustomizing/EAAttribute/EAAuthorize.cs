using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EAWebAPI.EACustomizing.EAAttribute
{
    public class EAAuthorize : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public EAAuthorize(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                // Eğer kullanıcı giriş yapmamışsa
                context.Result = new UnauthorizedObjectResult("Kullanıcı giriş yapmamış.");
                return;
            }

            // Role kontrolü
            var hasRole = _roles.Any(role => user.IsInRole(role));
            if (!hasRole)
            {
                context.Result = new ForbidResult("Yetki yok");
                return;
            }

            // isActive kontrolü
            var isActiveClaim = user.Claims.FirstOrDefault(c => c.Type == "IsActive");
            if (isActiveClaim == null || isActiveClaim.Value != "True")
            {
                context.Result = new ForbidResult("Kullanıcı pasife alınmış");
                return;
            }
        }
    }
}

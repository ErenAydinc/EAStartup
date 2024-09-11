namespace EAWebAPI.EACustomizing.Swagger
{
    public static class EndpointConfigurations
    {
        public static IEndpointRouteBuilder RegistrationEndpoints(this IEndpointRouteBuilder app)
        {
            //EndPoints.v1.ArticleController.MapProductApiEndpoints(app);
            //EndPoints.v2.ArticleController.MapProductApiEndpoints(app);
            return app;
        }
    }
}

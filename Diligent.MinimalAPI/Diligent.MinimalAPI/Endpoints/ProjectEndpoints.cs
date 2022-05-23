using Diligent.MinimalAPI.Services;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class ProjectEndpoints
    {
        // Extentions methods:
        // Services DI
        public static void AddProjectEndpoints(
            this IServiceCollection services)
        {
            services.AddSingleton<IProjectService, ProjectService>();
        }

        // Endpoints

        public static void UseProjectEndpoints(
            this IEndpointRouteBuilder app)
        {
            // app.MapGet("/", () => "Hello World!");
        }
    }
}

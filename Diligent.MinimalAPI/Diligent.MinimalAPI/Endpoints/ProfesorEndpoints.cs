using Diligent.MinimalAPI.Services;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class ProfesorEndpoints
    {
        // Extentions methods:
        // Services DI
        public static void AddProfesorEndpoints(
            this IServiceCollection services)
        {
            services.AddSingleton<IProfesorService, ProfesorService>();
        }

        // Endpoints

        public static void UseProfesorEndpoints(
            this IEndpointRouteBuilder app)
        {
            //app.MapGet("/", () => "Hello World!");
        }
    }
}

using Diligent.MinimalAPI.Services.Interfaces;
using Diligent.MinimalAPI.Services;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class ClassroomEndpoints
    {
        // Extentions methods:
        // Services DI
        public static void AddClassroomEndpoints(
            this IServiceCollection services)
        {
            services.AddSingleton<IClassroomService, ClassroomService>();
        }

        // Endpoints

        public static void UseClassroomEndpoints(
            this IEndpointRouteBuilder app)
        {
           // app.MapGet("/", () => "Hello World!");
        }
    }
}

using Diligent.MinimalAPI.Services.Interfaces;
using Diligent.MinimalAPI.Services;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class ClassroomEndpoints
    {
        private const string Tag = "Classroom";
        private const string BaseRoute = "classrooms";

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
           
        }
    }
}

using Diligent.MinimalAPI.Services.Interfaces;
using Diligent.MinimalAPI.Services;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class CourseEndpoints
    {
        // Extentions methods:
        // Services DI
        public static void AddCourseEndpoints(
            this IServiceCollection services)
        {
            services.AddSingleton<ICourseService, CourseService>();
        }

        // Endpoints

        public static void UseCourseEndpoints(
            this IEndpointRouteBuilder app)
        {
            // app.MapGet("/", () => "Hello World!");
        }
    }
}

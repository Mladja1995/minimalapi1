using Diligent.MinimalAPI.Services.Interfaces;
using Diligent.MinimalAPI.Services;
using Diligent.MinimalAPI.Models;

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
            app.MapPost("courses/create-course", (Course course, ICourseService courseService) =>
            {
                return Results.Ok(courseService.CreateCourse(course));
            });

            //app.MapGet("/", () => "Hello World!");
        }
    }
}

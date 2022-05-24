using Diligent.MinimalAPI.Services.Interfaces;
using Diligent.MinimalAPI.Services;
using Diligent.MinimalAPI.Models;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class CourseEndpoints
    {
        private const string Tag = "Course";
        private const string BaseRoute = "course";

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
            app.MapPost($"{BaseRoute}/create-course", (Course course, ICourseService courseService) =>
            {
                return Results.Ok(courseService.CreateCourse(course));
            }).WithTags(Tag);

            //app.MapGet("/", () => "Hello World!");
        }
    }
}

using Diligent.MinimalAPI.Services;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class StudentEndpoints
    {
        // Extentions methods:
        // Services DI
        public static void AddStudentEndpoints(
            this IServiceCollection services)
        {
            services.AddSingleton<IStudentService, StudentService>();
        }

        // Endpoints

        public static void UseStudentEndpoints(
            this IEndpointRouteBuilder app)
        {
            app.MapGet("/", () => "Hello World!");
        }
    }
}

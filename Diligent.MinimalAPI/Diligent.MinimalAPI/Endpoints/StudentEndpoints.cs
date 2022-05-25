using Diligent.MinimalAPI.Models;
using Diligent.MinimalAPI.Services;
using FluentValidation;
using FluentValidation.Results;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class StudentEndpoints
    {
        private const string Tag = "Students";
        private const string BaseRoute = "students";

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
            app.MapGet(BaseRoute, GetAllStudentsAsync)
                .WithTags(Tag);

            app.MapGet($"{BaseRoute}/{{id}}", GetStudentByIdAsync)
                .WithTags(Tag);

            app.MapPost(BaseRoute, CreateStudentAsync)
                .Produces<bool>(200).Produces<IEnumerable<ValidationFailure>>(400)
                .WithTags(Tag);

            app.MapPut($"{BaseRoute}/{{id}}", UpdateStudentAsync)
                .Produces<bool>(200).Produces<IEnumerable<ValidationFailure>>(400)
                .WithTags(Tag);

        }

        internal static async Task<IResult> GetAllStudentsAsync(IStudentService studentService)
        {
            return Results.Ok(await studentService.GetAllAsync());
        }
        internal static async Task<IResult> GetStudentByIdAsync(int id, IStudentService studentService)
        {
            return Results.Ok(await studentService.GetByIdAsync(id));
        }

        internal static async Task<IResult> CreateStudentAsync(Student student, IStudentService studentService, IValidator<Student> validator)
        {
            var validationResult = validator.Validate(student);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }
            return Results.Ok(await studentService.CreateStudentAsync(student));
        }
        internal static async Task<IResult> UpdateStudentAsync(Student student, int id, IStudentService studentService, IValidator<Student> validator)
        {
            var validationResult = validator.Validate(student);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }
            return Results.Ok(await studentService.UpdateStudentAsync(student, id));
        }
    }
}

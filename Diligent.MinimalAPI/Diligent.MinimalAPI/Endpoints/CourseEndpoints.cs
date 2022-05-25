using Diligent.MinimalAPI.Services.Interfaces;
using Diligent.MinimalAPI.Services;
using Diligent.MinimalAPI.Models;
using FluentValidation;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class CourseEndpoints
    {
        private const string Tag = "Course";
        private const string BaseRoute = "courses";

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
            app.MapPost(BaseRoute, CreateCourseAsync).WithTags(Tag);
            app.MapGet(BaseRoute, GetCoursesAsync).WithTags(Tag);
            app.MapGet($"{BaseRoute}/{{code}}", GetCourseByCodeAsync).WithTags(Tag);
            app.MapPut(BaseRoute, UpdateCourseAsync).WithTags(Tag);
            app.MapDelete($"{BaseRoute}/{{code}}", DeleteCourseAsync).WithTags(Tag);
        }


        private static async Task<IResult> CreateCourseAsync(Course course, ICourseService courseService, ILogger<Program> logger, IValidator<Course> validator)
        {
            try
            {
                var validationResult = await validator.ValidateAsync(course);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.Errors);
                }

                var isCreated = await courseService.CreateAsync(course);
                if (!isCreated)
                {
                    return Results.BadRequest(new
                    {
                        ErrorMessage = "Something went wrong please try again..."
                    });
                }

                return Results.Created($"{BaseRoute}/{course.Code}", course);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Results.StatusCode(500);
            }
        }

        private static async Task<IResult> GetCoursesAsync(ICourseService courseService, ILogger<Program> logger)
        {
            try
            {
                var courses = await courseService.GetAllAsync();
                return Results.Ok(courses);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Results.StatusCode(500);
            }
        }

        private static async Task<IResult> GetCourseByCodeAsync(string code, ICourseService courseService, ILogger<Program> logger)
        {
            try
            {
                var course = await courseService.GetByCodeAsync(code);
                return Results.Ok(course);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Results.StatusCode(500);
            }
        }

        private static async Task<IResult> UpdateCourseAsync(Course course, ICourseService courseService, ILogger<Program> logger, IValidator<Course> validator)
        {
            try
            {
                var validationResult = await  validator.ValidateAsync(course);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.Errors);
                }

                var isUpdated = await courseService.UpdateAsync(course);
                return  isUpdated ? Results.Ok(course) : Results.NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Results.StatusCode(500);
            }
        }

        private static async Task<IResult> DeleteCourseAsync(string code, ICourseService courseService, ILogger<Program> logger)
        {
            try
            {
                var isDeleted = await courseService.DeleteAsync(code);
                return isDeleted ? Results.Ok() : Results.NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Results.StatusCode(500);
            }
        }
    }
}

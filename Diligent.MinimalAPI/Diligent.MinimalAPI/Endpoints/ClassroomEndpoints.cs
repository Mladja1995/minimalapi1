using Diligent.MinimalAPI.Services.Interfaces;
using Diligent.MinimalAPI.Services;
using Diligent.MinimalAPI.Models;
using FluentValidation;

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
            app.MapPost(BaseRoute, CreateClassroomAsync).WithTags(Tag);
            app.MapGet(BaseRoute, GetClassroomsAsync).WithTags(Tag);
            app.MapGet($"{BaseRoute}/{{identifier}}", GetClassroomByIdentifierAsync).WithTags(Tag);
            app.MapPut(BaseRoute, UpdateClassroomAsync).WithTags(Tag);
            app.MapDelete($"{BaseRoute}/{{identifier}}", DeleteClassroomAsync).WithTags(Tag);
        }

        private static async Task<IResult> CreateClassroomAsync(Classroom classroom, IClassroomService classroomService, ILogger<Program> logger, IValidator<Classroom> validator)
        {
            try
            {
                var validationResult = await validator.ValidateAsync(classroom);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.Errors);
                }

                var isCreated = await classroomService.CreateAsync(classroom);
                if (!isCreated)
                {
                    return Results.BadRequest(new
                    {
                        ErrorMessage = "Something went wrong please try again..."
                    });
                }

                return Results.Created($"{BaseRoute}/{classroom.Identifier}", classroom);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Results.StatusCode(500);
            }
        }

        private static async Task<IResult> GetClassroomsAsync(IClassroomService classroomService, ILogger<Program> logger)
        {
            try
            {
                var courses = await classroomService.GetAllAsync();
                return Results.Ok(courses);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Results.StatusCode(500);
            }
        }

        private static async Task<IResult> GetClassroomByIdentifierAsync(string identifier, IClassroomService classroomService, ILogger<Program> logger)
        {
            try
            {
                var course = await classroomService.GetByIdentifierAsync(identifier);
                return Results.Ok(course);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Results.StatusCode(500);
            }
        }

        private static async Task<IResult> UpdateClassroomAsync(Classroom classroom, IClassroomService classroomService, ILogger<Program> logger, IValidator<Classroom> validator)
        {
            try
            {
                var validationResult = await validator.ValidateAsync(classroom);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.Errors);
                }

                var isUpdated = await classroomService.UpdateAsync(classroom);
                return isUpdated ? Results.Ok(classroom) : Results.NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Results.StatusCode(500);
            }
        }

        private static async Task<IResult> DeleteClassroomAsync(string identifier, IClassroomService classroomService, ILogger<Program> logger)
        {
            try
            {
                var isDeleted = await classroomService.DeleteAsync(identifier);
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

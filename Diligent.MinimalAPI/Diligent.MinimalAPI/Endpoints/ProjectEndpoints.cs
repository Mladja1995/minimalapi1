using Diligent.MinimalAPI.Models;
using Diligent.MinimalAPI.Services;
using FluentValidation;
using FluentValidation.Results;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class ProjectEndpoints
    {
        private const string Tag = "Project";
        private const string BaseRoute = "projects";

        // Extentions methods:
        // Services DI
        public static void AddProjectEndpoints(
            this IServiceCollection services)
        {
            services.AddSingleton<IProjectService, ProjectService>();
        }

        // Endpoints

        public static void UseProjectEndpoints(
            this IEndpointRouteBuilder app)
        {
           app.MapGet(BaseRoute, GetAllProjects)
                .WithTags(Tag);

            app.MapGet($"{BaseRoute}/{{id}}", GetProjectById)
                 .WithTags(Tag);

            app.MapPost(BaseRoute, CreateProject)
               .Produces<bool>(200).Produces<IEnumerable<ValidationFailure>>(400)
               .WithTags(Tag);

            app.MapPut(BaseRoute, UpdateProject)
               .WithTags(Tag);

            app.MapDelete($"{BaseRoute}/{{id}}", DeleteProject)
                .WithTags(Tag);
        }

        internal static async Task<List<Project>> GetAllProjects(IProjectService projectService)
        {
            return await projectService.GetAllAsync();
        }

        internal static async Task<IResult> GetProjectById(int id, IProjectService projectService)
        {
            return Results.Ok(await projectService.GetProjectByIdAsync(id));
        }

        internal static async Task<IResult> CreateProject(Project project, IProjectService projectService, IValidator<Project> validator)
        {
            var validationResult = validator.Validate(project);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }
            return Results.Ok(await projectService.CreateProject(project));
        }

        internal static async Task<bool> UpdateProject(Project project, IProjectService projectService)
        {
            return await projectService.UpdateProjectAsync(project);
        }

        internal static async Task<bool> DeleteProject(int id, IProjectService projectService)
        {
            return await projectService.DeleteProjectAsync(id);
        }
    }
}

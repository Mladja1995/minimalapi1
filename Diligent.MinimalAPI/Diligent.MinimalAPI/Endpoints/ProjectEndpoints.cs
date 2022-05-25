using Diligent.MinimalAPI.Models;
using Diligent.MinimalAPI.Services;
using FluentValidation;
using FluentValidation.Results;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class ProjectEndpoints
    {
        private const string Tag = "Projects";
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

            app.MapGet($"{BaseRoute}/{{name}}", GetProjectByName)
                 .WithTags(Tag);

            app.MapPost(BaseRoute, CreateProject)
               .Produces<bool>(200).Produces<IEnumerable<ValidationFailure>>(400)
               .WithTags(Tag);

            app.MapPut(BaseRoute, UpdateProject)
               .WithTags(Tag);

            app.MapDelete($"{BaseRoute}/{{name}}", DeleteProject)
                .WithTags(Tag);
        }

        internal static async Task<List<Project>> GetAllProjects(IProjectService projectService)
        {
            return await projectService.GetAllAsync();
        }

        internal static async Task<IResult> GetProjectByName(string name, IProjectService projectService)
        {
            return Results.Ok(await projectService.GetProjectByNameAsync(name));
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

        internal static async Task<bool> DeleteProject(string name, IProjectService projectService)
        {
            return await projectService.DeleteProjectAsync(name);
        }
    }
}

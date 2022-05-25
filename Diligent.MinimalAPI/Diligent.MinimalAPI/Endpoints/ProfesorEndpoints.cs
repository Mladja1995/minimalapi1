using Diligent.MinimalAPI.Models;
using Diligent.MinimalAPI.Services;
using FluentValidation;
using FluentValidation.Results;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class ProfesorEndpoints
    {
        private const string Tag = "Profesor";
        private const string BaseRoute = "profesors";

        // Extentions methods:
        // Services DI
        public static void AddProfesorEndpoints(
            this IServiceCollection services)
        {
            services.AddSingleton<IProfesorService, ProfesorService>();
        }

        // Endpoints

        public static void UseProfesorEndpoints(
            this IEndpointRouteBuilder app)
        {
            app.MapGet(BaseRoute, GetAllProfesors)
                 .WithTags(Tag);

            app.MapGet($"{BaseRoute}/{{id}}", GetProfesorById)
                 .WithTags(Tag);

            app.MapPost(BaseRoute, CreateProfesor)
               .Produces<bool>(200).Produces<IEnumerable<ValidationFailure>>(400)
               .WithTags(Tag);

            app.MapPut(BaseRoute, UpdateProfesor)
               .WithTags(Tag);

            app.MapDelete($"{BaseRoute}/{{id}}", DeleteProfesor)
                .WithTags(Tag);
        }

        internal static async Task<List<Profesor>> GetAllProfesors(IProfesorService profesorService)
        {
            return await profesorService.GetAllAsync();
        }

        internal static async Task<IResult> GetProfesorById(int id, IProfesorService profesorService)
        {
            return Results.Ok(await profesorService.GetProfesorById(id));
        }

        internal static async Task<IResult> CreateProfesor(Profesor profesor, IProfesorService profesorService, IValidator<Profesor> validator)
        {
            var validationResult = validator.Validate(profesor);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }
            return Results.Ok(await profesorService.CreateProfesor(profesor));
        }

        internal static async Task<bool> UpdateProfesor(Profesor profesor, IProfesorService profesorService)
        {
            return await profesorService.UpdateProfesorAsync(profesor);
        }

        internal static async Task<bool> DeleteProfesor(int id, IProfesorService profesorService)
        {
            return await profesorService.DeleteProfesorAsync(id);
        }
    }
}

using Diligent.MinimalAPI.Services;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class BookEndpoints
    {
        // Extentions methods:
        // Services DI
        public static void AddBookEndpoints(
            this IServiceCollection services)
        {
            services.AddSingleton<IBookService, BookService>();
        }

        // Endpoints

        public static void UseBookEndpoints(
            this IEndpointRouteBuilder app)
        {
            //app.MapGet("/", () => "Hello World!");
        }
    }
}

using Diligent.MinimalAPI.Models;
using Diligent.MinimalAPI.Services;
using FluentValidation;
using FluentValidation.Results;

namespace Diligent.MinimalAPI.Endpoints
{
    public static class BookEndpoints
    {
        private const string Tag = "Books";
        private const string BaseRoute = "books";

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
            app.MapGet(BaseRoute, GetAllBooks)
                 .WithTags(Tag);

            app.MapGet($"{BaseRoute}/{{title}}", GetBookByTitle)
                 .WithTags(Tag);

            app.MapPost(BaseRoute, CreateBook)
               .Produces<bool>(200).Produces<IEnumerable<ValidationFailure>>(400)
               .WithTags(Tag);

            app.MapPut(BaseRoute, UpdateBook)
               .WithTags(Tag);

            app.MapDelete($"{BaseRoute}/{{title}}", DeleteBook)
                .WithTags(Tag);
        }

        internal static async Task<List<Book>> GetAllBooks(IBookService bookservice)
        {
            return await bookservice.GetAllAsync();
        }

        internal static async Task<IResult> GetBookByTitle(string title, IBookService bookService)
        {
            return Results.Ok(await bookService.GetBookByTitleAsync(title));
        }

        internal static async Task<IResult> CreateBook(Book book, IBookService bookService, IValidator<Book> validator)
        {
            var validationResult = validator.Validate(book);
            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }
            return Results.Ok(await bookService.CreateBook(book));
        }

        internal static async Task<bool> UpdateBook(Book book, IBookService bookService)
        {
            return await bookService.UpdateBookAsync(book);
        }

        internal static async Task<bool> DeleteBook(string title, IBookService bookService)
        {
            return await bookService.DeleteBookAsync(title);
        }
    }
}

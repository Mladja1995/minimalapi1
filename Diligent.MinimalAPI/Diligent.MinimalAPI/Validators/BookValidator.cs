using Diligent.MinimalAPI.Models;
using FluentValidation;

namespace Diligent.MinimalAPI.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Title).NotEmpty();
            RuleFor(book => book.PublishDate).NotNull();
            RuleFor(book => book.Author).NotEmpty();
            RuleFor(book => book.ISBN).NotEmpty();
        }
    }
}

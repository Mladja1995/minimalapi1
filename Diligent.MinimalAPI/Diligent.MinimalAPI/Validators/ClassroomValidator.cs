using Diligent.MinimalAPI.Models;
using FluentValidation;

namespace Diligent.MinimalAPI.Validators
{
    public class ClassroomValidator : AbstractValidator<Classroom>
    {
        public ClassroomValidator()
        {
            RuleFor(x => x.Identifier).NotEmpty();
            RuleFor(x => x.NumberOfSeats).NotNull();
            RuleFor(x => x.Floor).NotNull();
            RuleFor(x => x.Section).NotEmpty();
            RuleFor(x => x.Type).NotNull();
        }
    }
}

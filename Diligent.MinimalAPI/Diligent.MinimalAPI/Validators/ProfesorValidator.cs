using Diligent.MinimalAPI.Models;
using FluentValidation;

namespace Diligent.MinimalAPI.Validators
{
    public class ProfesorValidator : AbstractValidator<Profesor>
    {
        public ProfesorValidator()
        {
            RuleFor(profesor => profesor.FirstName).NotEmpty();
            RuleFor(profesor => profesor.LastName).NotEmpty();
            RuleFor(profesor => profesor.CourseId).NotNull();
        }
    }
}

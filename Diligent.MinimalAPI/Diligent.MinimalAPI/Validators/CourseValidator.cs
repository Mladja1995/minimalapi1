using Diligent.MinimalAPI.Models;
using FluentValidation;

namespace Diligent.MinimalAPI.Validators
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Semestar).NotNull();
            RuleFor(x => x.ProfesorId).NotNull();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.CreatedDate).NotNull();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}

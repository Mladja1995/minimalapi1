using Diligent.MinimalAPI.Models;
using FluentValidation;

namespace Diligent.MinimalAPI.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(student => student.FirstName).NotEmpty();
            RuleFor(student => student.LastName).NotEmpty();
            RuleFor(student => student.IndexNum).NotNull();
        }
    }
}

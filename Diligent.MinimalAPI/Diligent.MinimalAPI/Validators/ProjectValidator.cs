using Diligent.MinimalAPI.Models;
using FluentValidation;

namespace Diligent.MinimalAPI.Validators
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(project => project.ProjectName).NotEmpty();
            RuleFor(project => project.CourseId).NotNull();
            RuleFor(project => project.StudentId).NotNull();
            RuleFor(project => project.ProfesorId).NotNull();
            RuleFor(project => project.StartDate).NotNull();
            RuleFor(project => project.EndDate).NotNull();
        }
    }
}

using FluentValidation;
using Integrated_Construction_Management_System_ICMS.Contracts.Requests;

namespace Integrated_Construction_Management_System_ICMS.Contracts.Validations
{
    public class ProjectValidator:AbstractValidator<ProjectRequest>
    {
        public ProjectValidator()
        {
            RuleFor(x=>x.ProjectName).NotEmpty();
        }

    }
}

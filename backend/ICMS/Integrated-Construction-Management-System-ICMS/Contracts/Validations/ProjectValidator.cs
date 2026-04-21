using FluentValidation;
using Integrated_Construction_Management_System_ICMS.Contracts.Requests;

namespace Integrated_Construction_Management_System_ICMS.Contracts.Validations
{
    public class ProjectValidator : AbstractValidator<ProjectRequest>
    {
        private readonly IProjectService _projectService;
        public ProjectValidator(IProjectService projectService)
        {
            _projectService = projectService;
            RuleFor(x => x.Name).NotEmpty()
                .MustAsync(HasUniqeName)
                .WithMessage("Project already exists");
        }
        public async Task<bool> HasUniqeName(string name, CancellationToken cancellationToken)
        {
          return !await _projectService.ExistsByNameAsync(name);
        }
    }
}


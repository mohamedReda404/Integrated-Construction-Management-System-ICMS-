using FluentValidation;
using Integrated_Construction_Management_System_ICMS.Contracts.Requests;

namespace Integrated_Construction_Management_System_ICMS.Contracts.Validations
{
    public class DrawingValidator : AbstractValidator<DrawingRequest>
    {
        public DrawingValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");

            RuleFor(x => x.Section)
                .NotEmpty().WithMessage("Section is required");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required");

            RuleFor(x => x.ProjectId)
                .GreaterThan(0).WithMessage("ProjectId must be greater than 0");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required");
        }
    }
}
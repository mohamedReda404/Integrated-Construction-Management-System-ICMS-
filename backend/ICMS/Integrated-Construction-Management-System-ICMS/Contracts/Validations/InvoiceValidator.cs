using FluentValidation;
using Integrated_Construction_Management_System_ICMS.Contracts.Requests;

namespace Integrated_Construction_Management_System_ICMS.Contracts.Validations
{
    public class InvoiceValidator : AbstractValidator<InvoiceRequest>
    {
        public InvoiceValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required");

            RuleFor(x => x.ProjectId)
                .GreaterThan(0).WithMessage("ProjectId must be greater than 0");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Total amount must be greater than 0");

            RuleFor(x => x.PeriodFrom)
                .LessThan(x => x.PeriodTo)
                .WithMessage("PeriodFrom must be before PeriodTo");

            RuleFor(x => x.InvoiceDate)
                .NotEmpty();
        }
    }
}
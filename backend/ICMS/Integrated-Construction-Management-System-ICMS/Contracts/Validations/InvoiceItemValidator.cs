using FluentValidation;
using Integrated_Construction_Management_System_ICMS.Contracts.Requests;

namespace Integrated_Construction_Management_System_ICMS.Contracts.Validations
{
    public class InvoiceItemValidator : AbstractValidator<InvoiceItemRequest>
    {
        public InvoiceItemValidator()
        {
            RuleFor(x => x.InvoiceId)
                .GreaterThan(0).WithMessage("InvoiceId must be greater than 0");

            RuleFor(x => x.Previous_qty)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Current_qty)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Total_qty)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Rate)
                .GreaterThan(0).WithMessage("Rate must be greater than 0");

            RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(0);
        }
    }
}
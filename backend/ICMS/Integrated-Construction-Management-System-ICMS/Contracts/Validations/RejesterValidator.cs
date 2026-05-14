
using Integrated_Construction_Management_System_ICMS.Contracts.Requests;
using RegisterRequest = Integrated_Construction_Management_System_ICMS.Contracts.Requests.RegisterRequest;

namespace Integrated_Construction_Management_System_ICMS.Contracts.Validations
{
    public class RejesterValidator : AbstractValidator<RegisterRequest>
    {
        public RejesterValidator()
        {
            RuleFor(e => e.Email)
              .NotEmpty()
              .EmailAddress();

            RuleFor(p => p.Password)
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches("[0-9]").WithMessage("Password must contain at least one number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character");
        }
    }
}

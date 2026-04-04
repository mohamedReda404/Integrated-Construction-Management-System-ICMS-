using FluentValidation;
using Integrated_Construction_Management_System_ICMS.Contracts.Authrization;

namespace Integrated_Construction_Management_System_ICMS.Contracts.Validations
{
    public class LoginValidator : AbstractValidator<LoginReques>
    {
        public LoginValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(p => p.password).NotEmpty();
        }
    }
}

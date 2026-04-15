using LoginRequest = Integrated_Construction_Management_System_ICMS.Contracts.Requests.LoginRequest;

namespace Integrated_Construction_Management_System_ICMS.Contracts.Validations
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}

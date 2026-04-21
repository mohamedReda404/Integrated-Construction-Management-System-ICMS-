namespace Integrated_Construction_Management_System_ICMS.Contracts.Validations
{
    public class BOQValidator:AbstractValidator<BOQRequest>
    {
        private readonly IBOQServices _BOQServices;
        public BOQValidator(IBOQServices BOQServices)
        {
            _BOQServices = BOQServices;
            RuleFor(x => x.Title).NotEmpty()
                .MustAsync(HasUniqeName)
                .WithMessage("BOQ already exists");
        }
        public async Task<bool> HasUniqeName(string title, CancellationToken cancellationToken)
        {
            return !await _BOQServices.ExistsByNameAsync(title);
        }
    }
}

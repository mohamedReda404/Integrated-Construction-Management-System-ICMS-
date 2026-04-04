

namespace Integrated_Construction_Management_System_ICMS.Services.Interfaces
{
    public interface IAuthServices
    {
        Task<Authresponce?> Login(string Email, string Password, CancellationToken cancellationToken=default);
        Task<Authresponce?> Rejester(RejesterRequest rejester,CancellationToken cancellationToken=default);
    }
}

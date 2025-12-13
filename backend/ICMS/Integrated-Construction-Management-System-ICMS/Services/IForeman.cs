using Integrated_Construction_Management_System_ICMS.Models;

namespace Integrated_Construction_Management_System_ICMS.Services
{
    public interface IForeman
    {
        Task<Foreman> Get(int id);
    }
}

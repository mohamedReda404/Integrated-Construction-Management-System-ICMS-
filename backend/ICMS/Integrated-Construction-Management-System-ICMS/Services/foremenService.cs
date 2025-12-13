using Integrated_Construction_Management_System_ICMS.Models;
using System.Threading.Tasks;

namespace Integrated_Construction_Management_System_ICMS.Services
{
    public class foremenService(AppDbContext context) : IForeman
    {
        private readonly AppDbContext _context= context;
        public async Task<Foreman> Get(int id)
        {
            return await _context.Foremen.FindAsync(id);
        }
    }
}

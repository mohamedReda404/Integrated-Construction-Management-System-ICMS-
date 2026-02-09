using Integrated_Construction_Management_System_ICMS.Models;
using Integrated_Construction_Management_System_ICMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class ForemanService
        : GenericService<Foreman>, IForemanService
    {
        public ForemanService(DbContext context)
            : base(context)
        {
        }
    }
}

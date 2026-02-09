using Integrated_Construction_Management_System_ICMS.Models;
using Integrated_Construction_Management_System_ICMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class EngineerBoqService
        : GenericService<EngineerBoq>, IEngineerBoqService
    {
        public EngineerBoqService(DbContext context)
            : base(context)
        {

        }
    }
}

using Integrated_Construction_Management_System_ICMS.Models;
using Integrated_Construction_Management_System_ICMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class ProjectSubConsultantService
        :GenericService<ProjectSubConsultant>, IProjectSubConsultantService
    {
        public ProjectSubConsultantService(DbContext context)
            : base(context)
        {
        }
    }
}

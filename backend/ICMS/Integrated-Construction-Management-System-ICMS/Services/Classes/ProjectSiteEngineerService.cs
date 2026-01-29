using Integrated_Construction_Management_System_ICMS.Models;
using Integrated_Construction_Management_System_ICMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class ProjectSiteEngineerService
        :GenericService<ProjectSiteEngineer>, IProjectSiteEngineerService
    {
        public ProjectSiteEngineerService(DbContext context)
            : base(context)
        {
        }
    }
}

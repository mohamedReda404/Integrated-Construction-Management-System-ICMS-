using Integrated_Construction_Management_System_ICMS.Models;

namespace Integrated_Construction_Management_System_ICMS.Services
{
    public interface IProjectManager
    {
        Task<ProjectManager> Get(int id);
        Task<ProjectManager> AddNew(ProjectManager manager);
        Task<bool> Delete(int id);
    }
}


namespace Integrated_Construction_Management_System_ICMS.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAll();
        Task<Project> GetId(int id);
        Task<Project> AddNew(Project project);
        Task<bool> Update(int id,Project project);
        Task<bool> Delete(int id);
    }
}

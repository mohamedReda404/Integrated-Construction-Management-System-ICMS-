
namespace Integrated_Construction_Management_System_ICMS.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAll(CancellationToken cancellationToken = default);
        Task<Project> GetId(int id,CancellationToken cancellationToken=default);
        Task<Project> AddNew(Project project, CancellationToken cancellationToken = default);
        Task<bool> Update(int id,Project project, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}

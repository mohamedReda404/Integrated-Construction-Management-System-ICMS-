
namespace Integrated_Construction_Management_System_ICMS.Services.Interfaces
{
    public interface IProjectService
    { 
        Task<IEnumerable<ProjectResponce?>> GetAll(CancellationToken cancellationToken = default);
        Task<ProjectResponce?> GetId(int id,CancellationToken cancellationToken=default);
        Task<ProjectResponce> AddNew(ProjectRequest request, CancellationToken cancellationToken = default);
        Task<bool> Update(int id, ProjectRequest request, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}


namespace Integrated_Construction_Management_System_ICMS.Services.Interfaces
{
    public interface IProjectContractService
    {
        Task<IEnumerable<ProjectContractResponce?>> GetAll(CancellationToken cancellationToken = default);
        Task<ProjectContractResponce?> GetId(int id, CancellationToken cancellationToken = default);
        Task<ProjectContractResponce> AddNew(ProjectContractRequest request, CancellationToken cancellationToken = default);
        Task<bool> Update(int id, ProjectContractRequest request, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}

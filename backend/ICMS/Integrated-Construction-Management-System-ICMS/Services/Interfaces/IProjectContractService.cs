public interface IProjectContractService
{
    Task<IEnumerable<ProjectContract>> GetAll(CancellationToken cancellationToken);
    Task<ProjectContract?> GetId(int id, CancellationToken cancellationToken);
    Task<ProjectContract> AddNew(ProjectContract projectContract, CancellationToken cancellationToken);
    Task<bool> Update(int id, ProjectContract projectContract, CancellationToken cancellationToken);
    Task<bool> Delete(int id, CancellationToken cancellationToken);
}
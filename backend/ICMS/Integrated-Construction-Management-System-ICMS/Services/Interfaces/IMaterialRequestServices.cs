namespace Integrated_Construction_Management_System_ICMS.Services.Interfaces
{
    public interface IMaterialRequestServices
    {
        Task<IEnumerable<MaterialRequestReponse?>> GetAll(CancellationToken cancellationToken = default);
        Task<MaterialRequestReponse?> GetId(int id, CancellationToken cancellationToken = default);
        Task<MaterialRequestReponse> AddNew(MaterialRequestRequest request, CancellationToken cancellationToken = default);
        Task<bool> Update(int id, MaterialRequestRequest request, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

    }
}

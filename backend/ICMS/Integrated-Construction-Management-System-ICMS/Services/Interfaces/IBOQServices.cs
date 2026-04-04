
namespace Integrated_Construction_Management_System_ICMS.Services.Interfaces
{
    public interface IBOQServices
    {
        Task<IEnumerable<BOQResponce?>> GetAll(CancellationToken cancellationToken = default);
        Task<BOQResponce?> GetId(int id, CancellationToken cancellationToken = default);
        Task<BOQResponce> AddNew( BOQRequest request, CancellationToken cancellationToken = default);
        Task<bool> Update(int id, BOQRequest request, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}

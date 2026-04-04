namespace Integrated_Construction_Management_System_ICMS.Services.Interfaces
{
    public interface IBOQPricingServices
    {
       

        Task<IEnumerable<BOQPricingReponce?>> GetAll(CancellationToken cancellationToken = default);
        Task<BOQPricingReponce?> GetId(int id, CancellationToken cancellationToken = default);
        Task<BOQPricingReponce> AddNew(BOQPricingRequest request, CancellationToken cancellationToken = default);
        Task<bool> Update(int id, BOQPricingRequest request, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}

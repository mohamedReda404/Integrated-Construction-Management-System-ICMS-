using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

public interface IInvoiceService
{
    Task<IEnumerable<InvoiceResponse?>> GetAll(CancellationToken cancellationToken = default);
    Task<InvoiceResponse?> GetId(int id, CancellationToken cancellationToken = default);
    Task<InvoiceResponse> AddNew(InvoiceRequest request, CancellationToken cancellationToken = default);
    Task<bool> Update(int id, InvoiceRequest request, CancellationToken cancellationToken = default);
    Task<bool> Delete(int id, CancellationToken cancellationToken = default);
}
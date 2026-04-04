using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

public interface IInvoiceItemService
{
    Task<IEnumerable<InvoiceItemResponse?>> GetAll(CancellationToken cancellationToken = default);
    Task<InvoiceItemResponse?> GetById(int id, CancellationToken cancellationToken = default);
    Task<InvoiceItemResponse> AddNew(InvoiceItemRequest request, CancellationToken cancellationToken = default);
    Task<bool> Update(int id, InvoiceItemRequest request, CancellationToken cancellationToken = default);
    Task<bool> Delete(int id, CancellationToken cancellationToken = default);
}
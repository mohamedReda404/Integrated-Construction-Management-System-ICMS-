using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

public interface IDrawingService
{
    Task<IEnumerable<DrawingResponse?>> GetAll(CancellationToken cancellationToken = default);
    Task<DrawingResponse?> GetId(int id, CancellationToken cancellationToken = default);
    Task<DrawingResponse> AddNew(DrawingRequest request, CancellationToken cancellationToken = default);
    Task<bool> Update(int id, DrawingRequest request, CancellationToken cancellationToken = default);
    Task<bool> Delete(int id, CancellationToken cancellationToken = default);
}
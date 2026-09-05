
namespace Integrated_Construction_Management_System_ICMS.Services.Interfaces
{
    public interface IWorkerTasks
    {
        Task<IEnumerable<WorkerTasksResponce?>> GetAll(CancellationToken cancellationToken = default);
        Task<WorkerTasksResponce?> GetId(int id, CancellationToken cancellationToken = default);
        Task<WorkerTasksResponce> AddNew(WworkerTasksRequest request, CancellationToken cancellationToken = default);
        Task<bool> Update(int id, WworkerTasksRequest request, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
        
    }
}

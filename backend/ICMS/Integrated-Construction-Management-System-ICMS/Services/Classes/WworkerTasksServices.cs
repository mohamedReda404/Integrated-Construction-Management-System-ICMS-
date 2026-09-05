using Integrated_Construction_Management_System_ICMS.Contracts.Responses;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    
    public class WworkerTasksServices(AppDbContext dbContext) : IWorkerTasks
    {
        private readonly AppDbContext _dbContext = dbContext;
        public async Task<WorkerTasksResponce> AddNew(WworkerTasksRequest request, CancellationToken cancellationToken = default)
        {
            var New = request.Adapt<WorkerTasksRequest>();
            await _dbContext.AddAsync(New);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return New.Adapt<WorkerTasksResponce>();
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var DELE = await _dbContext.WorkerTasksR.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (DELE is null) { return false; }
            _dbContext.WorkerTasksR.Remove(DELE);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<WorkerTasksResponce?>> GetAll(CancellationToken cancellationToken = default)
        {
            var AllResponce = await _dbContext.WorkerTasksR.AsNoTracking().ToListAsync(cancellationToken);
            return AllResponce.Adapt<IEnumerable<WorkerTasksResponce>>();
        }

        public async Task<WorkerTasksResponce?> GetId(int id, CancellationToken cancellationToken = default)
        {
            var One = await _dbContext.WorkerTasksR.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return One.Adapt<WorkerTasksResponce>();
        }

        public async Task<bool> Update(int id, WworkerTasksRequest request, CancellationToken cancellationToken = default)
        {
            var workerTasksRequest = request.Adapt<WorkerTasksRequest>();
            var workerTasks = await _dbContext.WorkerTasksR.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (workerTasksRequest is null) { return false; }
            workerTasks.ProjectId = workerTasksRequest.ProjectId;
            workerTasks.AppliactionUserId = workerTasksRequest.AppliactionUserId;
            workerTasks.Title = workerTasksRequest.Title;
            workerTasks.Decription = workerTasksRequest.Decription;
            workerTasks.Quantity = workerTasksRequest.Quantity;
            workerTasks.Notes = workerTasksRequest.Notes;
            workerTasks.Date = workerTasksRequest.Date;
      
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

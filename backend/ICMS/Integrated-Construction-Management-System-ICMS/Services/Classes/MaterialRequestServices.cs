using Integrated_Construction_Management_System_ICMS.Contracts.Responces;
using Integrated_Construction_Management_System_ICMS.Models;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class MaterialRequestServices(AppDbContext dbContext) : IMaterialRequestServices
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<MaterialRequestResponse> AddNew(MaterialRequestRequest request, CancellationToken cancellationToken = default)
        {
            var entity = request.Adapt<MaterialRequest>();

            await _dbContext.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Adapt<MaterialRequestResponse>();
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<MaterialRequest>().FindAsync(id);

            if (entity is null)
                return false;

            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<MaterialRequestResponse>> GetAll(CancellationToken cancellationToken = default)
        {
            var list = await _dbContext.Set<MaterialRequest>()
                .AsNoTracking()
            .ToListAsync(cancellationToken);

            return list.Adapt<IEnumerable<MaterialRequestResponse>>();
        }

        public async Task<MaterialRequestResponse?> GetId(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<MaterialRequest>()
            .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return entity?.Adapt<MaterialRequestResponse>();
        }

        public async Task<bool> Update(int id, MaterialRequestRequest request, CancellationToken cancellationToken = default)
        {
            var requestMaterialRequest = request.Adabt<MaterialRequest>();
            var materialRequest = GetId(id).Adabt<MaterialRequest>();

            if (materialRequest is null) { return false; }

            entity.ProjectId = request.ProjectId;
            entity.ApplicationUserId = request.ApplicationUserId;
            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Status = request.Status;
            entity.Notes = request.Notes;
            entity.RequestDate = request.RequestDate;
            entity.RequiredDate = request.RequiredDate;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}

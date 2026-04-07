using Integrated_Construction_Management_System_ICMS.Contracts.Responces;
using Integrated_Construction_Management_System_ICMS.Models;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class MaterialRequestServices(AppDbContext dbContext) : IMaterialRequestServices
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<MaterialRequestReponse> AddNew(MaterialRequestRequest request, CancellationToken cancellationToken = default)
        {
            var NewRequest = request.Adapt<MaterialsRequest>();
            await _dbContext.AddAsync(NewRequest, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return NewRequest.Adapt<MaterialRequestReponse>();
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var Request = GetId(id).Adapt<MaterialsRequest>();
            if (Request is null) { return false; }
            _dbContext.MaterialsRequest.Remove(Request);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<MaterialRequestReponse?>> GetAll(CancellationToken cancellationToken = default)
        {
            var AllmResponce = await _dbContext.MaterialsRequest.AsNoTracking().ToListAsync(cancellationToken);
            return AllmResponce.Adapt<IEnumerable<MaterialRequestReponse>>();
        }

        public async Task<MaterialRequestReponse?> GetId(int id, CancellationToken cancellationToken = default)
        {
            var OnemResponce = await _dbContext.MaterialsRequest.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return OnemResponce.Adapt<MaterialRequestReponse>();
        }

        public async Task<bool> Update(int id, MaterialRequestRequest request, CancellationToken cancellationToken = default)
        {
            var mrequest = request.Adapt<MaterialsRequest>();
            var project = GetId(id).Adapt<MaterialsRequest>();
            if (project is null) { return false; }
            project.ProjectId = mrequest.ProjectId;
            project.ApplicationUserId = mrequest.ApplicationUserId;
            project.Title = mrequest.Title;
            project.Description = mrequest.Description;
            project.Status = mrequest.Status;
            project.Notes = mrequest.Notes;
            project.RequestDate = mrequest.RequestDate;
            project.RequiredDate = mrequest.RequiredDate;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        
    }
}

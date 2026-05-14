

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class ProjectContractService(AppDbContext dbContext) : IProjectContractService
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<ProjectContractResponce> AddNew(ProjectContractRequest request, CancellationToken cancellationToken = default)
        {
            var NewProjectContract = request.Adapt<ProjectContract>();
            await _dbContext.AddAsync(NewProjectContract);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return NewProjectContract.Adapt<ProjectContractResponce>();
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var projectContract = GetId(id).Adapt<ProjectContract>();
            if (projectContract is null) { return false; }
            _dbContext.ProjectContracts.Remove(projectContract);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<ProjectContractResponce?>> GetAll(CancellationToken cancellationToken = default)
        {
            var AllProjectsContractResponce = await _dbContext.ProjectContracts.AsNoTracking().ToListAsync(cancellationToken);
            return AllProjectsContractResponce.Adapt<IEnumerable<ProjectContractResponce>>();
        }

        public async Task<ProjectContractResponce?> GetId(int id, CancellationToken cancellationToken = default)
        {
            var OneprojectContract = await _dbContext.ProjectContracts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return OneprojectContract.Adapt<ProjectContractResponce>();
        }

        public async Task<bool> Update(int id, ProjectContractRequest request, CancellationToken cancellationToken = default)
        {
            var requestProjectContract = request.Adapt<ProjectContract>();
            var projectContract = GetId(id).Adapt<ProjectContract>();
            if (projectContract is null) { return false; }
            projectContract.Name = requestProjectContract.Name;
            projectContract.Duration = requestProjectContract.Duration;
            projectContract.Date = requestProjectContract.Date;
            projectContract.RetentionPercentage = requestProjectContract.RetentionPercentage;
            projectContract.AdvancePayment = requestProjectContract.AdvancePayment;
            projectContract.Value = requestProjectContract.Value;
            projectContract.File = requestProjectContract.File;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
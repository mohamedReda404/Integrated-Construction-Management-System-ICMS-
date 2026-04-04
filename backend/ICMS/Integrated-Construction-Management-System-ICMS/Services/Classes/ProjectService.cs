
namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class ProjectService(AppDbContext dbContext) : IProjectService
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<ProjectResponce> AddNew(ProjectRequest request, CancellationToken cancellationToken = default)
        {
           var NewProject=request.Adapt<Project>();
           await _dbContext.AddAsync(NewProject);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return NewProject.Adapt<ProjectResponce>();
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var project = GetId(id).Adapt<Project>();
            if (project is null) { return false; }
            _dbContext.projects.Remove(project);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
        public async Task<IEnumerable<ProjectResponce?>> GetAll(CancellationToken cancellationToken = default)
        {
           var AllProjectsResponce=await _dbContext.projects.AsNoTracking().ToListAsync(cancellationToken);
            return AllProjectsResponce.Adapt<IEnumerable<ProjectResponce>>();
        }

        public async Task<ProjectResponce?> GetId(int id, CancellationToken cancellationToken = default)
        {
            var Oneproject = await _dbContext.projects.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
            return Oneproject.Adapt<ProjectResponce>();
        }

        public async Task<bool> Update(int id, ProjectRequest request, CancellationToken cancellationToken = default)
        {
            var requestProject= request.Adapt<Project>();
            var project = GetId(id).Adapt<Project>();
            if (project is null) { return false; }
            project.Name= requestProject.Name; 
            project.Location = requestProject.Location; 
            project.Descritpion = requestProject.Descritpion; 
            project.Category = requestProject.Category; 
            project.ClientName = requestProject.ClientName; 
            project.ContractValue = requestProject.ContractValue; 
            project.Photo = requestProject.Photo; 
            project.StartDate = requestProject.StartDate; 
            project.EndDate = requestProject.EndDate; 
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

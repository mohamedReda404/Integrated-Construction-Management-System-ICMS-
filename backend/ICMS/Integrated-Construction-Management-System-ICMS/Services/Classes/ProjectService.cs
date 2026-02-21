
namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _dbContext;

        public ProjectService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Project> AddNew(Project project, CancellationToken cancellationToken = default)
        {
           await _dbContext.projects.AddAsync(project, cancellationToken);
           await _dbContext.SaveChangesAsync(cancellationToken);
            return project;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var _project = await GetId(id, cancellationToken);

            if (_project is null)
            {
                return false;
            }
            else
            {
                _dbContext.projects.Remove(_project);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }

        }

        public async Task<IEnumerable<Project>> GetAll(CancellationToken cancellationToken = default)=>
            await _dbContext.projects.ToListAsync(cancellationToken);

        public async Task<Project> GetId(int id, CancellationToken cancellationToken = default) =>
            await _dbContext.projects.FirstOrDefaultAsync(i => i.ProjectID==id, cancellationToken);

        public async Task<bool> Update(int id, Project project, CancellationToken cancellationToken = default)
        {
           var _project= await GetId(id, cancellationToken);
            if (_project != null)
            {
                _project.ProjectName=project.ProjectName;
                _project.ProjectDescritpion=project.ProjectDescritpion;
                _project.ProjectLocation=project.ProjectLocation;
                _project.prjectContract=project.prjectContract;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}

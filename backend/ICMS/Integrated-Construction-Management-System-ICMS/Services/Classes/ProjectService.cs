
namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _dbContext;

        public ProjectService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Project> AddNew(Project project)
        {
           await _dbContext.projects.AddAsync(project);
           await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<bool> Delete(int id)
        {
            var _project = await GetId(id);

            if (_project is null)
            {
                return false;
            }
            else
            {
                _dbContext.Remove(_dbContext);
                await _dbContext.SaveChangesAsync();
                return true;
            }

        }

        public async Task<IEnumerable<Project>> GetAll()=>
            await _dbContext.projects.ToListAsync();

        public async Task<Project> GetId(int id) =>
            await _dbContext.projects.FirstOrDefaultAsync(i => i.ProjectID==id);

        public async Task<bool> Update(int id, Project project)
        {
           var _project= await GetId(id);
            if (_project != null)
            {
                _project.ProjectName=project.ProjectName;
                _project.ProjectDescritpion=project.ProjectDescritpion;
                _project.ProjectLocation=project.ProjectLocation;
                _project.prjectContract=project.prjectContract;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}

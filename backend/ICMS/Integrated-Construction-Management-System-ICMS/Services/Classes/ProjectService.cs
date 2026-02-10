using Integrated_Construction_Management_System_ICMS.Models;
using Microsoft.EntityFrameworkCore;
using Integrated_Construction_Management_System_ICMS.Persistence;
using Integrated_Construction_Management_System_ICMS.Services.Interfaces;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _dbContext;

        public ProjectService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Project>> GetAll()=>
            await _dbContext.projects.ToListAsync();

        public async Task<Project> GetId(int id) =>
            await _dbContext.projects.FirstOrDefaultAsync(i => i.ProjectID==id);
       
    }
}

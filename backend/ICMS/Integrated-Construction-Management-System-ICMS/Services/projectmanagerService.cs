using Integrated_Construction_Management_System_ICMS.Models;

namespace Integrated_Construction_Management_System_ICMS.Services
{
    public class projectmanagerService(AppDbContext context) : IProjectManager
    {
        private readonly AppDbContext _context = context;

        public async Task<ProjectManager> AddNew(ProjectManager manager)
        {
            await _context.AddAsync(manager);
            await _context.SaveChangesAsync();
            return manager;
        }

        public async Task<bool> Delete(int id)
        {
            var currentManager = await Get(id);

            if (currentManager == null)
                return false;

            _context.ProjectManagers.Remove(currentManager);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<ProjectManager> Get(int id)
        {
            return await _context.ProjectManagers.FindAsync(id);
        }


    }
}

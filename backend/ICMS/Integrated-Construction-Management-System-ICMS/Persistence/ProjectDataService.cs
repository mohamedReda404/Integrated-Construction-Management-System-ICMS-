using Microsoft.EntityFrameworkCore;
using Integrated_Construction_Management_System_ICMS.Models;

namespace Integrated_Construction_Management_System_ICMS.Persistence
{
    public class ProjectDataService
    {
        private readonly AppDbContext _context;

        public ProjectDataService(AppDbContext context)
        {
            _context = context;
        }

        // كل المشاريع
        public async Task<List<Project>> GetAll()
        {
            return await _context.projects
                .Where(p => !string.IsNullOrEmpty(p.Name))
                .ToListAsync();
        }

        // حسب المدينة
        public async Task<List<Project>> GetByLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return new List<Project>();

            location = location.ToLower();

            return await _context.projects
                .Where(p => p.Location != null &&
                            p.Location.ToLower().Contains(location))
                .ToListAsync();
        }

        // بحث ذكي
        public async Task<List<Project>> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return new List<Project>();

            keyword = keyword.ToLower();

            return await _context.projects
                .Where(p =>
                    (p.Name != null && p.Name.ToLower().Contains(keyword)) ||
                    (p.Category != null && p.Category.ToLower().Contains(keyword)) ||
                    (p.ClientName != null && p.ClientName.ToLower().Contains(keyword)) ||
                    (p.Location != null && p.Location.ToLower().Contains(keyword)) ||
                    (p.Descritpion != null && p.Descritpion.ToLower().Contains(keyword))
                )
                .ToListAsync();
        }

        // 🔥 Get project by ID
        public async Task<Project?> GetById(int id)
        {
            return await _context.projects
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // 🔥 BOQ per project (NEW)
        public async Task<List<BOQ>> GetProjectBOQ(int projectId)
        {
            return await _context.Set<BOQ>()
                .Where(b => b.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<List<Drawing>> GetProjectDrawings(int projectId)
        {
            return await _context.Set<Drawing>()
                .Where(d => d.ProjectId == projectId)
                .ToListAsync();
        }

        // Field extraction helper
        public string GetField(Project project, string field)
        {
            if (project == null)
                return "No project data available.";

            return field switch
            {
                "Category" => project.Category ?? "N/A",
                "Location" => project.Location ?? "N/A",
                "ClientName" => project.ClientName ?? "N/A",
                "Description" => project.Descritpion ?? "N/A",
                "Name" => project.Name ?? "N/A",
                _ => "Field not found"
            };
        }
    }
}
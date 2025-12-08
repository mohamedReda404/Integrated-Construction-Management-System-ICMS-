using Integrated_Construction_Management_System_ICMS.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrated_Construction_Management_System_ICMS
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ICMS;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<MainClient> MainClients { get; set; }
        
    }

}

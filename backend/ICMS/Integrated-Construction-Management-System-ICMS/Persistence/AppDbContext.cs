using Integrated_Construction_Management_System_ICMS.Models;
using Microsoft.EntityFrameworkCore;

namespace Integrated_Construction_Management_System_ICMS.Persistence
{
    public class AppDbContext: DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }


        public DbSet<Project> projects { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<MainClient> MainClients { get; set; }
        public DbSet<ProjectContract> ProjectContracts { get; set; }
        public DbSet<Store> Stores  { get; set; }
        public DbSet<SubConsultant> SubConsultants { get; set; }
        public DbSet<SubContractor> SubContractors { get; set; }
        public DbSet<SiteEngineer> SiteEngineers { get; set; }
        public DbSet<Foreman> Foremen { get; set; }
        public DbSet<MainClient> Mainclients { get; set; }
        public DbSet<MainConsultant> MainConsultants { get; set; }
        public DbSet<BoqCondtionConsultant> BoqCondtionConsultants { get; set; }
        public DbSet<BoqCondtionEng> BoqCondtionEngs { get; set; }
        public DbSet<ConsultantBoq> ConsultantBoqs { get; set; }
        public DbSet<EngineerBoq> EngineerBoqs { get; set; }
        public DbSet<EngineerInvoice> EngineerInvoices { get; set; }
        public DbSet<FormanTasks> FormanTasks { get; set; }
        public DbSet<GeneralDrowing> GeneralDrowings { get; set; }
        public DbSet<ProjectSiteEngineer> ProjectSiteEngineers { get; set; }
        public DbSet<ProjectSubConsultant> ProjectSubConsultants { get; set; }
        public DbSet<ProjectSubContractor> ProjectSubContractors { get; set; }
        public DbSet<ShopDrawing> ShopDrawings { get; set; }
        public DbSet<SiteEngineer> SiteEngineerss { get; set; }
        public DbSet<SubConstractorInvoice> SubConstractorInvoices { get; set; }
        public DbSet<SubConsultant> SubConsultantss { get; set; }


    }

}

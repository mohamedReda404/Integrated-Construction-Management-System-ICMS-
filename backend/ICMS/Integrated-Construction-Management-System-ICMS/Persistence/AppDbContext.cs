

using Azure.Core;

namespace Integrated_Construction_Management_System_ICMS.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
        : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Project> projects { get; set; }
        public DbSet<ProjectContract> ProjectContracts { get; set; }
        public DbSet<ProjectApplicationUser> ProjectApplicationUsers { get; set; }
        public DbSet<BOQ> BOQ { get; set; }
        public DbSet<BOQPricing> BOQPricing { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Drawing> Drawing { get; set; }
        public DbSet<Invoice> Invoice { get; set; } 
        public DbSet<InvoiceItem> InvoiceItem { get; set; }
        public DbSet<MaterialsRequest> MaterialsRequest { get; set; }
        //public DbSet<RefreshToken> RefreshTokens { get; set; }
        
    }
}

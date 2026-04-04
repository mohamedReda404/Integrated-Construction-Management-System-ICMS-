using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrated_Construction_Management_System_ICMS.Contracts.configurations
{
    public class ProjectApplicationUserConfigurations : IEntityTypeConfiguration<ProjectApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ProjectApplicationUser> builder)
        {
            builder.HasKey(x => new { x.ProjectId, x.ApplicationUserId });

            builder.HasOne(x => x.project)
                   .WithMany(p => p.projectApplicationUser)
                   .HasForeignKey(x => x.ProjectId);

            builder.HasOne(x => x.ApplicationUser)
                   .WithMany(p => p.projectApplicationUser)
                   .HasForeignKey(x => x.ApplicationUserId);
        }
    }
}

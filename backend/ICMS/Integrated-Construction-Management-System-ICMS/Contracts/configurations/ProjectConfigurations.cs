using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrated_Construction_Management_System_ICMS.Contracts.configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.ClientName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Location)
                .IsRequired();

            builder.Property(x => x.ContractValue)
                .IsRequired();

            builder.Property(x => x.Descritpion)
                .IsRequired();

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.EndDate)
                .IsRequired();


            builder.HasOne(x => x.projectContract)
                .WithOne(x => x.project)
                .HasForeignKey<ProjectContract>(f => f.ProjectId);

            builder.HasMany(x => x.projectApplicationUser)
                 .WithOne(x => x.project)
                 .HasForeignKey(f => f.ProjectId);

            builder.HasMany(x => x.bOQ)
                 .WithOne(x => x.project)
                 .HasForeignKey(f => f.ProjectId);

            //builder.HasMany(x => x.bOQPricing)
            //     .WithOne(x => x.project)
            //     .HasForeignKey(f => f.ProjectId);

            builder.HasMany(x => x.brawing)
                 .WithOne(x => x.project)
                 .HasForeignKey(f => f.ProjectId);

            builder.HasMany(x => x.Invoice)
                 .WithOne(x => x.project)
                 .HasForeignKey(f => f.ProjectId);

            //builder.HasMany(x => x.invoiceItem)
            //     .WithOne(x => x.Project)
            //     .HasForeignKey(f => f.ProjectId);

            builder.HasMany(x => x.materialsRequest)
             .WithOne(x => x.project)
             .HasForeignKey(f => f.ProjectId);

        }
    }
}

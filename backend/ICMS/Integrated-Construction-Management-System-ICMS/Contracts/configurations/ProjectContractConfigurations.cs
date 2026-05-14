using Integrated_Construction_Management_System_ICMS.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrated_Construction_Management_System_ICMS.Contracts.configurations
{
    public class ProjectContractConfigurations : IEntityTypeConfiguration<ProjectContract>
    {
        public void Configure(EntityTypeBuilder<ProjectContract> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.RetentionPercentage).IsRequired();
            builder.Property(x => x.AdvancePayment).IsRequired();
            builder.Property(x => x.File).IsRequired();

        }
    }
}

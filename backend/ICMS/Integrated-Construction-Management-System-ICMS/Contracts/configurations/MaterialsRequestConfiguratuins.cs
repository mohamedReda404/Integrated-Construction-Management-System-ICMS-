using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrated_Construction_Management_System_ICMS.Contracts.configurations
{
    public class MaterialsRequestConfiguratuins : IEntityTypeConfiguration<MaterialsRequest>
    {
        public void Configure(EntityTypeBuilder<MaterialsRequest> builder)
        {
            builder.Property(t=>t.Title).IsRequired().HasMaxLength(150);
            builder.Property(t=>t.Description).IsRequired().HasMaxLength(250);
            builder.Property(t=>t.Status).IsRequired().HasMaxLength(150);
            builder.Property(t=>t.Notes).IsRequired().HasMaxLength(200);
            builder.Property(t=>t.RequestDate).IsRequired();
            builder.Property(t=>t.RequiredDate).IsRequired();
        }
    }
}

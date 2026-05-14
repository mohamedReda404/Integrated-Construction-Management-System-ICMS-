using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrated_Construction_Management_System_ICMS.Contracts.configurations
{
    public class BOQPricingConfigurations : IEntityTypeConfiguration<BOQPricing>
    {
        public void Configure(EntityTypeBuilder<BOQPricing> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p=>p.TotalPrice)
                .IsRequired();

            builder.Property(p=>p.UnitRate)
                .IsRequired();

            builder.Property(p=>p.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p=>p.Date)
                .IsRequired();

            builder.HasOne(p => p.bOQ)
                .WithOne(b => b.bOQPricing)
                .HasForeignKey<BOQPricing>(f=>f.BOQId);

        }
    }
}

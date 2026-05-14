using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrated_Construction_Management_System_ICMS.Contracts.configurations
{
    public class InvoiceConfigurations : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.InvoiceDate)
               .IsRequired();

            builder.Property(t => t.PeriodFrom)
               .IsRequired();

            builder.Property(t => t.PeriodTo)
               .IsRequired();

            builder.Property(t => t.TotalAmount)
               .IsRequired();

            builder.Property(t => t.File)
               .IsRequired();

            
        }
    }
}

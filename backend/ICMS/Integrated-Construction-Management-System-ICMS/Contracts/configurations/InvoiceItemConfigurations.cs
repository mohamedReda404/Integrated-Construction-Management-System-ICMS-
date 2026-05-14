using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrated_Construction_Management_System_ICMS.Contracts.configurations
{
    public class InvoiceItemConfigurations : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.Property(p => p.Previous_qty)
                .IsRequired();

            builder.Property(p => p.Total_qty)
                .IsRequired();

            builder.Property(p => p.Current_qty)
                .IsRequired();

            builder.Property(p => p.Rate)
                .IsRequired();

            builder.Property(p => p.Amount)
                .IsRequired();

            builder.HasOne(i => i.invoice)
               .WithMany(I => I.invoiceItem)
               .HasForeignKey(f=>f.InvoiceId);

            //builder.HasOne(i => i.bOQ)
            //   .WithMany(I => I.invoiceItem)
            //   .HasForeignKey(f => f.BOQId);

        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrated_Construction_Management_System_ICMS.Contracts.configurations
{
    public class DrawingConfigurations : IEntityTypeConfiguration<Drawing>
    {
        public void Configure(EntityTypeBuilder<Drawing> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(s => s.Section)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(D => D.Date)
                .IsRequired();

            builder.Property(p => p.Photo)
                .IsRequired();
        }
    }
}

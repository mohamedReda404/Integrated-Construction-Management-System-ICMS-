using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrated_Construction_Management_System_ICMS.Contracts.configurations
{
    public class BOQConfigurations : IEntityTypeConfiguration<BOQ>
    {
        public void Configure(EntityTypeBuilder<BOQ> builder)
        {
            builder.Property(t=>t.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t=>t.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(t=>t.Condetion)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(t=>t.Section)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t=>t.Unit)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t=>t.Quantity)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t=>t.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t=>t.Date)
                .IsRequired();

            builder.Property(t=>t.File)
                .IsRequired();


          

           
        }
    }
}

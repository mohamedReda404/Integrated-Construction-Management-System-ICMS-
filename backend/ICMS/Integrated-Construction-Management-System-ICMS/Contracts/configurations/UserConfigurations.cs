using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Integrated_Construction_Management_System_ICMS.Contracts.configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            //builder.Property(x=>x.Email).IsRequired();
            //builder.Property(x => x.PhoneNumber).HasMaxLength(11);
            //builder.Property(x => x.PasswordHash).IsRequired();



            builder.HasMany(x => x.projectApplicationUser)
              .WithOne(x => x.ApplicationUser)
              .HasForeignKey(f => f.ApplicationUserId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.materialsRequest)
              .WithOne(x => x.ApplicationUser)
              .HasForeignKey(f => f.ApplicationUserId)
              .OnDelete(DeleteBehavior.NoAction); 

            builder.HasMany(x => x.bOQ)
              .WithOne(x => x.ApplicationUser)
              .HasForeignKey(f => f.ApplicationUserId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.drawing)
              .WithOne(x => x.ApplicationUser)
              .HasForeignKey(f => f.ApplicationUserId).
              OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.invoice)
              .WithOne(x => x.ApplicationUser)
              .HasForeignKey(f => f.ApplicationUserId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

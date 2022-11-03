using LFF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LFF.Infrastructure.EF.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id).HasName("PK_User_Id");
            modelBuilder.HasAlternateKey(u => u.Username).HasName("IX_User_Username");
            modelBuilder.HasAlternateKey(u => u.Email).HasName("IX_User_Email");
            modelBuilder.HasAlternateKey(u => u.CMND).HasName("IX_User_CMND");
            modelBuilder.Property(u => u.Id).IsRequired();
            modelBuilder.Property(u => u.Username).IsRequired().HasMaxLength(64);
            modelBuilder.Property(u => u.Password).IsRequired();
            modelBuilder.Property(u => u.FullName).IsRequired();
            modelBuilder.Property(u => u.Email).IsRequired().HasMaxLength(256);
            modelBuilder.Property(u => u.DateOfBirth).IsRequired();
            modelBuilder.Property(u => u.CMND).IsRequired().HasMaxLength(15);
            modelBuilder.Property(u => u.Role).IsRequired();
            modelBuilder.Property(u => u.CreatedAt).IsRequired();
            modelBuilder.Property(u => u.LastUpdatedAt).IsRequired();

        }
    }
}

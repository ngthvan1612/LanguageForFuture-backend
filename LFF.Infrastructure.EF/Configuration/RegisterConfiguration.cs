using LFF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LFF.Infrastructure.EF.Configuration
{
    public class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {

        public void Configure(EntityTypeBuilder<Register> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id).HasName("PK_Register_Id");
            modelBuilder.Property(u => u.Id).IsRequired();
            modelBuilder.Property(u => u.RegistrationDate).IsRequired();
            modelBuilder.Property(u => u.CreatedAt).IsRequired();
            modelBuilder.Property(u => u.LastUpdatedAt).IsRequired();

            modelBuilder
              .HasOne(u => u.Student)
              .WithMany(u => u.Registers)
              .HasForeignKey(u => u.StudentId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
              .HasOne(u => u.Class)
              .WithMany(u => u.Registers)
              .HasForeignKey(u => u.ClassId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

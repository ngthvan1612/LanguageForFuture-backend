using LFF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LFF.Infrastructure.EF.Configuration
{
    public class StudentTestConfiguration : IEntityTypeConfiguration<StudentTest>
    {

        public void Configure(EntityTypeBuilder<StudentTest> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id).HasName("PK_StudentTest_Id");
            modelBuilder.Property(u => u.Id).IsRequired();
            modelBuilder.Property(u => u.StartDate).IsRequired();
            modelBuilder.Property(u => u.CreatedAt).IsRequired();
            modelBuilder.Property(u => u.LastUpdatedAt).IsRequired();

            modelBuilder
              .HasOne(u => u.Student)
              .WithMany(u => u.StudentTests)
              .HasForeignKey(u => u.StudentId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
              .HasOne(u => u.Test)
              .WithMany(u => u.StudentTests)
              .HasForeignKey(u => u.TestId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

using LFF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LFF.Infrastructure.EF.Configuration
{
    public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
    {

        public void Configure(EntityTypeBuilder<Classroom> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id).HasName("PK_Classroom_Id");
            modelBuilder.HasAlternateKey(u => u.Name).HasName("IX_Classroom_Name");
            modelBuilder.Property(u => u.Id).IsRequired();
            modelBuilder.Property(u => u.Name).IsRequired().HasMaxLength(250);
            modelBuilder.Property(u => u.StartDate).IsRequired();
            modelBuilder.Property(u => u.NumberOfLessons).IsRequired();
            modelBuilder.Property(u => u.CreatedAt).IsRequired();
            modelBuilder.Property(u => u.LastUpdatedAt).IsRequired();

            modelBuilder
              .HasOne(u => u.Teacher)
              .WithMany()
              .HasForeignKey(u => u.TeacherId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
              .HasOne(u => u.Course)
              .WithMany()
              .HasForeignKey(u => u.CourseId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

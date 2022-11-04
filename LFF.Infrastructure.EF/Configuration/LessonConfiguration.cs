using LFF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LFF.Infrastructure.EF.Configuration
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {

        public void Configure(EntityTypeBuilder<Lesson> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id).HasName("PK_Lesson_Id");
            modelBuilder.Property(u => u.Id).IsRequired();
            modelBuilder.Property(u => u.Name).IsRequired();
            modelBuilder.Property(u => u.Description).IsRequired();
            modelBuilder.Property(u => u.StartTime).IsRequired();
            modelBuilder.Property(u => u.EndTime).IsRequired();
            modelBuilder.Property(u => u.CreatedAt).IsRequired();
            modelBuilder.Property(u => u.LastUpdatedAt).IsRequired();

            modelBuilder
              .HasOne(u => u.Class)
              .WithMany(u => u.Lessons)
              .HasForeignKey(u => u.ClassId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

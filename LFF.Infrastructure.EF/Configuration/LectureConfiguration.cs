using LFF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LFF.Infrastructure.EF.Configuration
{
    public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {

        public void Configure(EntityTypeBuilder<Lecture> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id).HasName("PK_Lecture_Id");
            modelBuilder.Property(u => u.Id).IsRequired();
            modelBuilder.Property(u => u.Name).IsRequired();
            modelBuilder.Property(u => u.Description).IsRequired();
            modelBuilder.Property(u => u.Content).IsRequired();
            modelBuilder.Property(u => u.CreatedAt).IsRequired();
            modelBuilder.Property(u => u.LastUpdatedAt).IsRequired();

            modelBuilder
              .HasOne(u => u.Lesson)
              .WithMany()
              .HasForeignKey(u => u.LessonId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

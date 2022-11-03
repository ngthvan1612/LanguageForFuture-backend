using LFF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LFF.Infrastructure.EF.Configuration
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {

        public void Configure(EntityTypeBuilder<Test> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id).HasName("PK_Test_Id");
            modelBuilder.Property(u => u.Id).IsRequired();
            modelBuilder.Property(u => u.Name).IsRequired();
            modelBuilder.Property(u => u.Description).IsRequired();
            modelBuilder.Property(u => u.StartDate).IsRequired();
            modelBuilder.Property(u => u.EndDate).IsRequired();
            modelBuilder.Property(u => u.NumberOfAttempts).IsRequired();
            modelBuilder.Property(u => u.Time).IsRequired();
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

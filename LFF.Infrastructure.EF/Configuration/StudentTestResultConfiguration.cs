using LFF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LFF.Infrastructure.EF.Configuration
{
    public class StudentTestResultConfiguration : IEntityTypeConfiguration<StudentTestResult>
    {

        public void Configure(EntityTypeBuilder<StudentTestResult> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id).HasName("PK_StudentTestResult_Id");
            modelBuilder.Property(u => u.Id).IsRequired();
            modelBuilder.Property(u => u.Result).IsRequired();
            modelBuilder.Property(u => u.CreatedAt).IsRequired();
            modelBuilder.Property(u => u.LastUpdatedAt).IsRequired();

            modelBuilder
              .HasOne(u => u.StudentTest)
              .WithMany()
              .HasForeignKey(u => u.StudentTestId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
              .HasOne(u => u.Question)
              .WithMany()
              .HasForeignKey(u => u.QuestionId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

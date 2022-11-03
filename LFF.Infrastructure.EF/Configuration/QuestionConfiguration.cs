using LFF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LFF.Infrastructure.EF.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {

        public void Configure(EntityTypeBuilder<Question> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id).HasName("PK_Question_Id");
            modelBuilder.Property(u => u.Id).IsRequired();
            modelBuilder.Property(u => u.Content).IsRequired();
            modelBuilder.Property(u => u.QuestionType).IsRequired();
            modelBuilder.Property(u => u.CreatedAt).IsRequired();
            modelBuilder.Property(u => u.LastUpdatedAt).IsRequired();

            modelBuilder
              .HasOne(u => u.Test)
              .WithMany()
              .HasForeignKey(u => u.TestId)
              .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

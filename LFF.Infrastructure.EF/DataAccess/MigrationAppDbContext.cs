using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LFF.Infrastructure.EF.DataAccess
{
    public class MigrationAppDbContext : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=__Test_004_Migrations;Integrated Security=True;");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

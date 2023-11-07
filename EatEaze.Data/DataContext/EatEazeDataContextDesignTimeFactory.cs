using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace EatEaze.Data.DataContext
{
    public class EatEazeDataContextDesignTimeFactory : IDesignTimeDbContextFactory<EatEazeDataContext>
    {
        #region IDesignTimeDbContextFactory<EatEazeDataContext> Members

        public EatEazeDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EatEazeDataContext>();
            optionsBuilder.UseNpgsql(
                "host=localhost;port=5432;database=eateazedatabase;username=eateaze-app;password=Ml37RemA7hEGjI");

            var context = new EatEazeDataContext(optionsBuilder.Options);
            context.Database.Migrate();

            return context;
        }

        #endregion
    }
}

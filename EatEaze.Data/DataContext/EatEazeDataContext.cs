using EatEaze.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EatEaze.Data.DataContext
{
    public class EatEazeDataContext : DbContext
    {
        public EatEazeDataContext(DbContextOptions<EatEazeDataContext> options) : base(options) 
        {

        } 
            
        #region DbSets

        public DbSet<City> Cities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Restaraunt> Restaraunts { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PositionInOrder> PositionsInOrders { get; set; }
        public DbSet<RestarauntInCity> RestarauntsInCities { get; set; }
        public DbSet<Category> Categories { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}

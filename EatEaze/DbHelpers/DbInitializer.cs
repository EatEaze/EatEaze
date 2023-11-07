using EatEaze.Data.DataContext;

namespace EatEaze.DbHelpers
{
    public static class DbInitializer
    {
        private static string[] _opt = { };
        private static EatEazeDataContext _eatEazeDataContext = new EatEazeDataContextDesignTimeFactory().CreateDbContext(_opt);

        public static void InitDatabase()
        {
            
        }
    }
}

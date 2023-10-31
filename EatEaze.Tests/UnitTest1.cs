using EatEaze.Data.DataContext;

namespace EatEaze.Tests
{
    public class Tests
    {
        private EatEazeDataContextDesignTimeFactory _contextFactory;

        [SetUp]
        public void Setup()
        {
            _contextFactory = new EatEazeDataContextDesignTimeFactory();
        }

        [Test]
        public void Test1()
        {
            string[] opt = { };
            _contextFactory.CreateDbContext(opt);
        }
    }
}
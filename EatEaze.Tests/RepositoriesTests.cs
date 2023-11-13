using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using EatEaze.Data.Repositiories.RepositoriesImpls;
using EatEaze.Data.DataContext;

namespace EatEaze.Tests
{
    public class RepositoriesTests
    {
        private EatEazeDataContext _eatEazeDataContext;
        private ICategoryRepository _categoryRepository;
        private IRestarauntsRepository _restarauntsRepository;
        private IPositionsRepository _positionsRepository;

        [SetUp]
        public void Setup() 
        {
            _eatEazeDataContext = new EatEazeDataContextDesignTimeFactory().CreateDbContext(null);
            _categoryRepository = new CategoriesRepository(_eatEazeDataContext);
            _restarauntsRepository = new RestarauntsRepository(_eatEazeDataContext);
            _positionsRepository = new PositionsRepository(_eatEazeDataContext);
        }

        [Test]
        public void GetListOfPositionsTest()
        { 
        }
    }
}

using EatEazeServices.Interfaces;
using EatEazeServices.Implementations;
using EatEaze.Data.DataContext;
using EatEaze.Data.Repositiories.RepositoriesImpls;

namespace EatEaze.Tests
{
    public class PositionsServiceTests
    {
        private IPositionsService _positionsService;

        [SetUp]
        public void SetUp()
        {
            string[] opt = { };
            EatEazeDataContext dataContext = new EatEazeDataContextDesignTimeFactory().CreateDbContext(opt);
            PositionsRepository pr = new PositionsRepository(dataContext);
            _positionsService = new PositionsService(pr);
        }

        [Test]
        public void GetPositionsTest()
        {
            var result = _positionsService.GetPositions().Result;
            Assert.That(!result.Equals(null));
        }
    }
}

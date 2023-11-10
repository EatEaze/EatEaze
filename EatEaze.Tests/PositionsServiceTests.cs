using EatEazeServices.Interfaces;
using EatEazeServices.Implementations;
using EatEaze.Data.Repositiories;
using EatEaze.Data.DataContext;

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

using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;

namespace EatEaze.Data.Repositiories
{
    public class PositionsRepository : BaseRepository<Position>
    {
        public PositionsRepository(EatEazeDataContext dataContext) : base(dataContext)
        {
        }

        public Position? TryGetPositionById(Guid positionId)
        {
            var position = _eatEazeDataContext.Positions.FirstOrDefault(p => p.PositionId == positionId);
            return position;
        }

        public IEnumerable<Position> GetPositionsByPositionName(string positionName)
        {
            var positions = _eatEazeDataContext.Positions.Where(p => p.PositionName == positionName);
            return positions;
        }

        public IEnumerable<Position> GetPositionsByRestaurantId(Guid restaurantId)
        {
            var positions = _eatEazeDataContext.Positions.Where(p => p.RestarauntId == restaurantId);
            return positions;
        }

        public IEnumerable<Position> GetPositionsByCategoryId(Guid categoryId)
        {
            var positions = _eatEazeDataContext.Positions.Where(p => p.CategoryId == categoryId);
            return positions;
        }

        public IEnumerable<Position> GetPositionsByCategoryIdAndRestaurantId(Guid categoryId, Guid restaurantId)
        {
            var positions = _eatEazeDataContext.Positions.Where(p => p.CategoryId == categoryId && p.RestarauntId == restaurantId);
            return positions;
        }
    }
}

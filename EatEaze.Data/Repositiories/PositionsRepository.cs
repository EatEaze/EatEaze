using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EatEaze.Data.Repositiories
{
    public class PositionsRepository : BaseRepository<Position>
    {
        public PositionsRepository(EatEazeDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<Position?> TryGetPositionById(Guid positionId)
        {
            var position = await _eatEazeDataContext.Positions.FirstOrDefaultAsync(p => p.PositionId == positionId);
            return position;
        }

        public async Task<IEnumerable<Position>> GetPositionsByPositionName(string positionName)
        {
            var positions = await _eatEazeDataContext.Positions.Where(p => p.PositionName.Contains(positionName)).ToListAsync();
            return positions;
        }

        public async Task<IEnumerable<Position>> GetPositionsByRestaurantId(Guid restaurantId)
        {
            var positions = await _eatEazeDataContext.Positions.Where(p => p.RestarauntId == restaurantId).ToListAsync();
            return positions;
        }

        public async Task<IEnumerable<Position>> GetPositionsByCategoryId(Guid categoryId)
        {
            var positions = await _eatEazeDataContext.Positions.Where(p => p.CategoryId == categoryId).ToListAsync();
            return positions;
        }

        public async Task<IEnumerable<Position>> GetPositionsByCategoryIdAndRestaurantId(Guid categoryId, Guid restaurantId)
        {
            var positions = await _eatEazeDataContext.Positions.Where(p => p.CategoryId == categoryId && p.RestarauntId == restaurantId).ToListAsync();
            return positions;
        }
    }
}

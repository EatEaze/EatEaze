using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;
using Microsoft.EntityFrameworkCore;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;

namespace EatEaze.Data.Repositiories.RepositoriesImpls
{
    public class PositionsRepository : IPositionsRepository
    {
        private EatEazeDataContext _eatEazeDataContext;

        public PositionsRepository(EatEazeDataContext dataContext) //: base(dataContext) 
        {
            _eatEazeDataContext = dataContext;
        }

        public async Task<Position?> TryGetPositionById(Guid positionId)
        {
            var position = await _eatEazeDataContext.Positions
                .Include(c => c.Category)
                .Include(r => r.Restaraunt)
                .FirstOrDefaultAsync(p => p.PositionId == positionId);
            return position;
        }

        public async Task<IEnumerable<Position>> GetPositionsByPositionName(string positionName)
        {
            var positions = await _eatEazeDataContext.Positions.Where(p => p.PositionName.Contains(positionName))
                .Include(c => c.Category)
                .Include(r => r.Restaraunt)
                .ToListAsync();
            return positions;
        }

        public async Task<IEnumerable<Position>> GetPositionsByRestaurantId(Guid restaurantId)
        {
            var positions = await _eatEazeDataContext.Positions.Where(p => p.RestarauntId == restaurantId)
                .Include(c => c.Category)
                .Include(r => r.Restaraunt)
                .ToListAsync();
            return positions;
        }

        public async Task<IEnumerable<Position>> GetPositionsByCategoryId(Guid categoryId)
        {
            var positions = await _eatEazeDataContext.Positions.Where(p => p.CategoryId == categoryId)
                .Include(c => c.Category)
                .Include(r => r.Restaraunt)
                .ToListAsync();
            return positions;
        }

        public async Task<IEnumerable<Position>> GetPositionsByCategoryIdAndRestaurantId(Guid categoryId, Guid restaurantId)
        {
            var positions = await _eatEazeDataContext.Positions.Where(p => p.CategoryId == categoryId && p.RestarauntId == restaurantId)
                .Include(c => c.Category)
                .Include(r => r.Restaraunt)
                .ToListAsync();
            return positions;
        }

        public async Task AddItem(Position item)
        {
            await _eatEazeDataContext.Positions.AddAsync(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task AddItem(IEnumerable<Position> items)
        {
            await _eatEazeDataContext.Positions.AddRangeAsync(items);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task DeleteItem(Position item)
        {
            _eatEazeDataContext.Positions.Remove(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Position>> GetPositionsFromRestarauntsInCity(City city)
        {
            var positionsInCity = from restarauntInCity in _eatEazeDataContext.RestarauntsInCities
                                  where restarauntInCity.CityId == city.CityId
                                  join restaraunt in _eatEazeDataContext.Restaraunts on restarauntInCity.RestarauntId equals restaraunt.RestarauntId
                                  join position in _eatEazeDataContext.Positions on restaraunt.RestarauntId equals position.RestarauntId
                                  select position;

            positionsInCity = positionsInCity.Include(c => c.Category).Include(r => r.Restaraunt);

            return await positionsInCity.ToListAsync();
        }

        public async Task DeleteItem(IEnumerable<Position> items)
        {
            _eatEazeDataContext.Positions.RemoveRange(items);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Position>> GetListOfItem()
        {
            return await _eatEazeDataContext.Positions
                .Include(c => c.Category)
                .Include(r => r.Restaraunt)
                .ThenInclude(c => c.RestarauntsInCities)
                .ToListAsync();
        }

        public async Task UpdateItem(Position item)
        {
            _eatEazeDataContext.Update(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }
    }
}

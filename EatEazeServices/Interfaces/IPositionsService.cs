using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface IPositionsService
    {
        public Task<IEnumerable<Position>> GetPositions();
        public Task<IEnumerable<Position>> GetPositions(string positionName);
        public Task<IEnumerable<Position>> GetPositionsByRestaurant(Guid restaurantId);
        public Task<IEnumerable<Position>> GetPositionsByCategory(Guid categoryId);
        public Task<IEnumerable<Position>> GetPositions(Guid restaurantId, Guid categoryId);
        public Task<IEnumerable<Position>> GetPositionsFromRestarauntsInCity(City city);
        public Task<Position> GetPositionById(Guid positionId);
        public Task AddPosition(Position position);
        public Task UpdatePosition(Position position);
        public Task RemovePosition(Position position);

    }
}

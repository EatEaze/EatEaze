using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface IPositionsService
    {
        public IEnumerable<Position> GetPositions();
        public IEnumerable<Position> GetPositions(string positionName);
        public IEnumerable<Position> GetPositionsByRestaurant(Guid restaurantId);
        public IEnumerable<Position> GetPositionsByCategory(Guid categoryId);
        public IEnumerable<Position> GetPositions(Guid restaurantId, Guid categoryId);
        public Position GetPositionById(Guid positionId);
        public void AddPosition(Position position);
        public void UpdatePosition(Position position);
        public void RemovePosition(Position position);

    }
}

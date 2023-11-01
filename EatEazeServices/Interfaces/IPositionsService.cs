using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface IPositionsService
    {
        public IEnumerable<Position> GetPositions();
        public IEnumerable<Position> GetPositions(string positionName);
        public IEnumerable<Position> GetPositionsByRestaraunt(Guid restarauntId);
        public IEnumerable<Position> GetPositionsByCategory(Guid categoryId);
        public IEnumerable<Position> GetPositions(Guid restarauntId, Guid categoryId);
        public Position GetPositionById();
    }
}

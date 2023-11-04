using EatEaze.Exceptions;
using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories;
using EatEazeServices.Interfaces;

namespace EatEazeServices.Implementations
{
    public class PositionsService : IPositionsService
    {
        private PositionsRepository _positionsRepository;

        public PositionsService(PositionsRepository positionsRepository)
        {
            _positionsRepository = positionsRepository; 
        }

        public void AddPosition(Position position)
        {
             _positionsRepository.AddItem(position);
        }

        public Position GetPositionById(Guid positionId)
        {
            var position = _positionsRepository.TryGetPositionById(positionId);

            if (position == null) throw new PositionNullException("Can't get position with this id");
            else return position;
        }

        public IEnumerable<Position> GetPositions()
        {
            var positions = _positionsRepository.GetListOfItem();
            return positions;
        }

        public IEnumerable<Position> GetPositions(string positionName)
        {
            var positions = _positionsRepository.GetPositionsByPositionName(positionName);
            return positions;
        }

        public IEnumerable<Position> GetPositions(Guid restaurantId, Guid categoryId)
        {
            var positions = _positionsRepository.GetPositionsByCategoryIdAndRestaurantId(categoryId, restaurantId);
            return positions;
        }

        public IEnumerable<Position> GetPositionsByCategory(Guid categoryId)
        {
            var positions = _positionsRepository.GetPositionsByCategoryId(categoryId);
            return positions;
        }

        public IEnumerable<Position> GetPositionsByRestaurant(Guid restaurantId)
        {
            var positions = _positionsRepository.GetPositionsByRestaurantId(restaurantId);
            return positions;
        }

        public void RemovePosition(Position position)
        {
            if (position == null) throw new PositionNullException("Position value is null");
            
            _positionsRepository.DeleteItem(position);
        }

        public void UpdatePosition(Position position)
        {
            if (position == null) throw new PositionNullException("Position value is null");

            _positionsRepository.DeleteItem(position);
        }
    }
}

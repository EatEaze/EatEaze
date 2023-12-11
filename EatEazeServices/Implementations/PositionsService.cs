using EatEaze.Exceptions;
using EatEaze.Data.Entities;
using EatEazeServices.Interfaces;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using EatEaze.Data.Repositiories.RepositoriesImpls;

namespace EatEazeServices.Implementations
{
    public class PositionsService : IPositionsService
    {
        private IPositionsRepository _positionsRepository;

        public PositionsService(IPositionsRepository positionsRepository)
        {
            _positionsRepository = positionsRepository;
        }

        public async Task AddPosition(Position position)
        {
             await _positionsRepository.AddItem(position);
        }

        public async Task<Position> GetPositionById(Guid positionId)
        {
            var position = await _positionsRepository.TryGetPositionById(positionId);

            if (position == null) throw new PositionNullException("Can't get position with this id");
            else return position;
        }

        public async Task<IEnumerable<Position>> GetPositions()
        {
            var positions = await _positionsRepository.GetListOfItem();
            return positions;
        }

        public async Task<IEnumerable<Position>> GetPositionsFromRestarauntsInCity(City city)
        {
            var positions = await _positionsRepository.GetPositionsFromRestarauntsInCity(city);
            return positions;
        }

        public async Task<IEnumerable<Position>> GetPositions(string positionName)
        {
            var positions = await _positionsRepository.GetPositionsByPositionName(positionName);
            return positions;
        }

        public async Task<IEnumerable<Position>> GetPositions(Guid restaurantId, Guid categoryId)
        {
            var positions = await _positionsRepository.GetPositionsByCategoryIdAndRestaurantId(categoryId, restaurantId);
            return positions;
        }

        public async Task<IEnumerable<Position>> GetPositionsByCategory(Guid categoryId)
        {
            var positions = await _positionsRepository.GetPositionsByCategoryId(categoryId);
            return positions;
        }

        public async Task<IEnumerable<Position>> GetPositionsByRestaurant(Guid restaurantId)
        {
            var positions = await _positionsRepository.GetPositionsByRestaurantId(restaurantId);
            return positions;
        }

        public async Task RemovePosition(Position position)
        {
            if (position == null) throw new PositionNullException("Position value is null");
            
            await _positionsRepository.DeleteItem(position);
        }

        public async Task UpdatePosition(Position position)
        {
            if (position == null) throw new PositionNullException("Position value is null");

            await _positionsRepository.DeleteItem(position);
        }
    }
}

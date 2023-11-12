
using EatEaze.Data.Entities;

namespace EatEaze.Data.Repositiories.RepositoriesInterfaces
{
    public interface IPositionRepository
    {
        Task<Position?> TryGetPositionById(Guid positionId);
        Task<IEnumerable<Position>> GetPositionsByPositionName(string positionName);
        Task<IEnumerable<Position>> GetPositionsByRestaurantId(Guid restaurantId);
        Task<IEnumerable<Position>> GetPositionsByCategoryId(Guid categoryId);
        Task<IEnumerable<Position>> GetPositionsByCategoryIdAndRestaurantId(Guid categoryId, Guid restaurantId);

    }
}

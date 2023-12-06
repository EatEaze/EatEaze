using EatEaze.Data.Entities;

namespace EatEaze.Data.Repositiories.RepositoriesInterfaces
{
    public interface IOrdersRepository : IBaseRepository<Order>
    {
        public Task<Order?> TryGetOrderWithoutOrderDateForUser(Guid userId);
    }
}

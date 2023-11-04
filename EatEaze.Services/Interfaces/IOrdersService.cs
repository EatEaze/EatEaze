using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface IOrdersService
    {
        public IEnumerable<Order> GetOrders();
        public IEnumerable<Order> GetOrders(Guid userId);
    }
}

using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface IOrdersService
    {
        public Task<IEnumerable<Order>> GetOrders();
        public Task<IEnumerable<Order>> GetOrders(Guid userId);
        public Task SetOrderFromBasket(Order basket, DateTime date, string address);
    }
}

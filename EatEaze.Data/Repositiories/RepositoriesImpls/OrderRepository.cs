using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EatEaze.Data.Repositiories.RepositoriesImpls
{
    public class OrderRepository : IOrdersRepository
    {
        private EatEazeDataContext _eatEazeDataContext;

        public OrderRepository(EatEazeDataContext dataContext) // : base(dataContext)
        {
            _eatEazeDataContext = dataContext;
        }

        public async Task AddItem(Order item)
        {
            await _eatEazeDataContext.Orders.AddAsync(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public Task AddItem(IEnumerable<Order> items)
        {
            throw new NotImplementedException();
        }

        public async Task AddItemInOrder(Order order, Position position, int count)
        {
            var item = new PositionInOrder() { OrderId = order.OrderId, Order = order, Count = count, PositionId = position.PositionId, Position = position };
            order.PositionsInOrders.Add(item);
            _eatEazeDataContext.Update(order);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public Task DeleteItem(Order item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItem(IEnumerable<Order> items)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetListOfItem()
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> TryGetOrderWithoutOrderDateForUser(Guid userId)
        {
            var result = await _eatEazeDataContext.Orders.Include(p => p.PositionsInOrders).ThenInclude(p => p.Position).FirstOrDefaultAsync(u => u.UserId == userId);
            return result;
        }

        public Task UpdateItem(Order item)
        {
            throw new NotImplementedException();
        }
    }
}

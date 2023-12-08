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
            PositionInOrder? item;
            if (!IsPositionExistInOrder(order, position.PositionId))
            {
                item = new PositionInOrder() { OrderId = order.OrderId, Order = order, Count = count, PositionId = position.PositionId, Position = position };
                order.PositionsInOrders.Add(item);
            }
            else
            {
                item = order.PositionsInOrders.FirstOrDefault(pio => pio.PositionId == position.PositionId && pio.OrderId == order.OrderId);
                if (item == null) throw new Exception();
                item.Count += count;
            }
            
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

        public async Task DeletePositionFromOrder(PositionInOrder positionInOrder)
        {
            _eatEazeDataContext.PositionsInOrders.Remove(positionInOrder);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Order>> GetListOfItem()
        {
            throw new NotImplementedException();
        }

        public bool IsPositionExistInOrder(Order order, Guid positionId)
        {
            var result = order.PositionsInOrders.FirstOrDefault(p => p.PositionId == positionId);
            return result == null ? false : true;
        }

        public async Task<Order?> TryGetOrderWithoutOrderDateForUser(Guid userId)
        {
            var result = await _eatEazeDataContext.Orders.Include(p => p.PositionsInOrders).ThenInclude(p => p.Position).FirstOrDefaultAsync(u => u.UserId == userId);
            return result;
        }

        public async Task UpdateItemInOrder(PositionInOrder positionInOrder)
        {
            _eatEazeDataContext.Update(positionInOrder);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public Task UpdateItem(Order item)
        {
            throw new NotImplementedException();
        }
    }
}

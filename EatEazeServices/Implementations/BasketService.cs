using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using EatEazeServices.Interfaces;

namespace EatEaze.Services.Implementations
{
    public class BasketService : IBasketService
    {
        private IOrdersRepository _ordersRepository;

        public BasketService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<Order> GetBasketForUser(Guid userId)
        {
            var result = await _ordersRepository.TryGetOrderWithoutOrderDateForUser(userId);
            if (result != null) return result;

            var basket = new Order() { UserId = userId };

            await _ordersRepository.AddItem(basket);
            result = await _ordersRepository.TryGetOrderWithoutOrderDateForUser(userId);
            if (result != null) return result;
            else throw new Exception();
        }

        public async Task AddToBasket(Order order, Position position, int count)
        { 
            await _ordersRepository.AddItemInOrder(order, position, count);

        }

        public async Task DeleteItemFromBasket(PositionInOrder positionInOrder)
        {
            await _ordersRepository.DeletePositionFromOrder(positionInOrder);
        }

        public async Task RemoveOneItemFromBasket(PositionInOrder positionInOrder)
        {
            positionInOrder.Count = positionInOrder.Count - 1;
            await _ordersRepository.UpdateItemInOrder(positionInOrder);
        }
    }
}

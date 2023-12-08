using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface IBasketService
    {
        public Task<Order> GetBasketForUser(Guid userId);
        public Task AddToBasket(Order order, Position position, int count);
        public Task DeleteItemFromBasket(PositionInOrder positionInOrder);
        public Task RemoveOneItemFromBasket(PositionInOrder positionInOrder);
    }
}

using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface IBasketService
    {
        public Task<Order> GetBasketForUser(Guid userId);
    }
}

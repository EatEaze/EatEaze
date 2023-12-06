using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using EatEazeServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using EatEazeServices.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatEaze.Services.Implementations
{
    public class OrdersService : IOrdersService
    {
        private IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _ordersRepository.GetListOfItem();
        }

        public async Task<IEnumerable<Order>> GetOrders(Guid userId)
        {
            var result = await _ordersRepository.GetListOfItem();
            result = result.Where(x => x.UserId == userId && x.OrderDate != null);
            if (result.Count() == 0) throw new Exception();
            return result;
        }

        public async Task SetOrderFromBasket(Order basket, DateTime date, string address)
        {
            basket.OrderDate = date;
            basket.Address = address;
            await _ordersRepository.UpdateItem(basket);
        }
    }
}

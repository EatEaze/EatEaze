using EatEaze.Data.Entities;
using EatEaze.Responce;
using EatEazeServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EatEaze.WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {

        private IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet, Route("basket/{userId}")]
        public async Task<IActionResult> GetBasket(Guid userId) 
        {
            var basket = await _basketService.GetBasketForUser(userId);
            if (basket == null) return NotFound();

            var basketDTO = new BasketDTO() { UserId = userId, OrderId = basket.OrderId, PositionsInOrders = basket.PositionsInOrders };

            return Ok(basketDTO);
        }
    }
}

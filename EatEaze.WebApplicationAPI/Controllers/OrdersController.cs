using EatEaze.Data.Entities;
using EatEazeServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EatEaze.WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IBasketService _basketService;
        private IOrdersService _ordersService;
        private readonly IConfiguration _configuration;

        public OrdersController(IBasketService basketService, IOrdersService ordersService, IConfiguration configuration)
        {
            _basketService = basketService;
            _ordersService = ordersService;
            _configuration = configuration;
        }

        [HttpGet, Route("orders/{token}")]
        public async Task<IActionResult> GetOrdersOfUser(string token)
        {
            Guid userId = _getUserIdFromToken(token);
            var orders = await _ordersService.GetOrders(userId);
            if (orders == null) return NotFound();
            return Ok(orders);
        }

        [HttpPut, Route("orders/setOrder/{token}/{address}/{date}")]
        public async Task<IActionResult> SetOrderFromBasket(string token, string address, DateTime date)
        {
            Guid userId = _getUserIdFromToken(token);
            var basket = await _basketService.GetBasketForUser(userId);
            if (basket == null) return NotFound("Can't find basket");
            try
            {
                await _ordersService.SetOrderFromBasket(basket, date, address);
                return Ok(basket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        private Guid _getUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return userId;
        }
    }
}

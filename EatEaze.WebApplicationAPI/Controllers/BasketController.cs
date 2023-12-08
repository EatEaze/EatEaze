using EatEaze.Data.Entities;
using EatEaze.Responce;
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
    public class BasketController : ControllerBase
    {
        private IConfiguration _configuration;
        private IBasketService _basketService;

        public BasketController(IBasketService basketService, IConfiguration configuration)
        {
            _basketService = basketService;
            _configuration = configuration;
        }

        [HttpGet, Route("basket/{token}")]
        public async Task<IActionResult> GetBasketForUser(string token) 
        {
            Guid userId = _getUserIdFromToken(token);
            var basket = await _basketService.GetBasketForUser(userId);
            if (basket == null) return NotFound();

            var basketDTO = new BasketDTO() { UserId = userId, OrderId = basket.OrderId, PositionsInOrders = basket.PositionsInOrders };

            return Ok(basketDTO);
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

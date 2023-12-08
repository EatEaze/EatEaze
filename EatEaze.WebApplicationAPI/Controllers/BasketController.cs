using AutoMapper;
using EatEaze.Data.Entities;
using EatEaze.Responce;
using EatEazeServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EatEaze.WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IConfiguration _configuration;
        private IPositionsService _positionsService;
        private IBasketService _basketService;

        public BasketController(IBasketService basketService, IConfiguration configuration, IMapper mapper, IPositionsService positionsService)
        {
            _basketService = basketService;
            _configuration = configuration;
            _mapper = mapper;
            _positionsService = positionsService;
        }

        [HttpGet, Route("basket/{token}")]
        public async Task<IActionResult> GetBasketForUser(string token) 
        {
            Guid userId = _getUserIdFromToken(token);
            var basket = await _basketService.GetBasketForUser(userId);
            if (basket == null) return NotFound();

            BasketDTO basketDTO = _mapper.Map<BasketDTO>(basket);

            return Ok(basketDTO);
        }

        [HttpPost, Route("basket/add/{token}/{modelId}")]
        public async Task<IActionResult> AddToBasket(Guid modelId, string token)
        {
            Guid userId = _getUserIdFromToken(token);
            var basket = await _basketService.GetBasketForUser(userId);
            if (basket == null) return NotFound("Can't find basket");
            
            Position position = await _positionsService.GetPositionById(modelId);

            await _basketService.AddToBasket(basket, position, 1);
            return Ok(position);

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

using EatEaze.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EatEaze.Data.Entities;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using EatEaze.Responce;
using System.Security.Claims;

namespace EatEaze.WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IAuthorizationService _authorizationService;
        private IConfiguration _configuration;

        public AuthorizationController(IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _authorizationService = authorizationService;
            _configuration = configuration;
        }

        [HttpPost, Route("Registration")]
        public async Task<IActionResult> RegistrateUser([FromBody] UserDTO model)
        {
            try
            {
                User user = new User() { Login = model.Login, Password = model.Password, Token = null, UserRoleId = model.UserRoleId };
                user = await _authorizationService.RegistrateUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet, Route("SignIn/{login}/{password}")]
        public async Task<IActionResult> SignIn(string login, string password)
        {
            try
            {
                var user = await _authorizationService.TryAuthorizeUser(login, password);

                if (user == null) return NotFound("Invalid user");

                user.Token = _generateToken(user);

                return Ok(user);
            }
            catch(Exception ex) 
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private string _generateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

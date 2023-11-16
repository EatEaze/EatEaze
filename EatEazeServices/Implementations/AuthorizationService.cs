using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using EatEaze.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
//using HashCodes.HashMethods;

namespace EatEaze.Services.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private IUserRepository _userRepository;

        public AuthorizationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> TryAuthorizeUser(string login, string password)
        {
            // string hashPassword = MD5Hash.CalculateMD5Hash(password);
            var result = await _userRepository.GetUserByLoginAndPassword(login, password);
            return result;
        }

        public async Task<User> RegistrateUser(User user)
        {
            await _userRepository.AddItem(user);

            return user;
        }
    }
}

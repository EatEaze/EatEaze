using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using EatEaze.Services.Interfaces;
using HashCodes.HashMethods;

namespace EatEaze.Services.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private IUserRepository _userRepository;

        public AuthorizationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AuthorizeUser(string login, string password)
        {
            string hashPassword = MD5Hash.CalculateMD5Hash(password);
            var result = await _userRepository.GetUserByLoginAndPassword(login, hashPassword);

            if (result == null) throw new Exception();

            return result;
        }

        public Task RegistrateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}

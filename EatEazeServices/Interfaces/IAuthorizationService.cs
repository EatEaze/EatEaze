using EatEaze.Data.Entities;

namespace EatEaze.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<User?> TryAuthorizeUser(string login, string password);
        Task<User> RegistrateUser(User user);

    }
}

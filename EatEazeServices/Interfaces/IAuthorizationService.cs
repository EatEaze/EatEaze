using EatEaze.Data.Entities;

namespace EatEaze.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task<User> AuthorizeUser(string login, string password);
        Task RegistrateUser(User user);
    }
}

using EatEaze.Data.Entities;

namespace EatEaze.Services.Interfaces
{
    public interface IAuthorizationService
    {
        Task AuthorizeUser(string login, string password);
    }
}

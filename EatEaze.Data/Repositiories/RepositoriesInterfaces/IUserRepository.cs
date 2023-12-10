using EatEaze.Data.Entities;

namespace EatEaze.Data.Repositiories.RepositoriesInterfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetUsersByRole(Guid roleId);

        Task<User?> TryGetUserByLoginAndPassword(string login, string password);
    }
}

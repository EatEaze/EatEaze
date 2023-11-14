using EatEaze.Data.Entities;

namespace EatEaze.Data.Repositiories.RepositoriesInterfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetUsersByRole(Guid roleId);

        Task<User> GetUserByLoginAndPassword(string login, string password);
    }
}

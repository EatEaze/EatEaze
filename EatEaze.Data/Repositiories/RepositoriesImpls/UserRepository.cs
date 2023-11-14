using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EatEaze.Data.Repositiories.RepositoriesImpls
{
    public class UserRepository : IUserRepository
    {
        private EatEazeDataContext _eatEazeDataContext;

        public UserRepository(EatEazeDataContext dataContext)
        {
            _eatEazeDataContext = dataContext;
        }

        public async Task AddItem(User item)
        {
            await _eatEazeDataContext.Users.AddAsync(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task AddItem(IEnumerable<User> items)
        {
            await _eatEazeDataContext.Users.AddRangeAsync(items);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task DeleteItem(User item)
        {
            _eatEazeDataContext.Users.Remove(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task DeleteItem(IEnumerable<User> items)
        {
            _eatEazeDataContext.Users.RemoveRange(items);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetListOfItem()
        {
            return await _eatEazeDataContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByLoginAndPassword(string login, string password)
        {
            var result = await _eatEazeDataContext.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);

            if (result == null) throw new Exception();
            return result;


        }

        public async Task<IEnumerable<User>> GetUsersByRole(Guid roleId)
        {
            var result = await _eatEazeDataContext.Users.Where(u => u.UserRoleId == roleId).ToListAsync();

            if (result == null) throw new Exception();
            return result;
        }

        public async Task UpdateItem(User item)
        {
            _eatEazeDataContext.Update(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }
    }
}

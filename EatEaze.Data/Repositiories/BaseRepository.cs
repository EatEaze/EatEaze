using EatEaze.Data.DataContext;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EatEaze.Data.Repositiories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected EatEazeDataContext _eatEazeDataContext;

        public BaseRepository(EatEazeDataContext dataContext)
        {
            _eatEazeDataContext = dataContext;
        }

        public async Task AddItem(T item)
        {
            await _eatEazeDataContext.Set<T>().AddAsync(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task AddItem(IEnumerable<T> items)
        {
            await _eatEazeDataContext.Set<T>().AddRangeAsync(items);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task DeleteItem(T item)
        {
            _eatEazeDataContext.Set<T>().Remove(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task DeleteItem(IEnumerable<T> items)
        {
            _eatEazeDataContext.Set<T>().RemoveRange(items);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetListOfItem()
        {
            return await _eatEazeDataContext.Set<T>().ToListAsync();
        }

        public async Task UpdateItem(T item)
        {
            _eatEazeDataContext.Update(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }
    }
}

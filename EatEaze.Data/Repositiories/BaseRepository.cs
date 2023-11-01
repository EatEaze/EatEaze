using EatEaze.Data.DataContext;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;

namespace EatEaze.Data.Repositiories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected EatEazeDataContext _eatEazeDataContext;

        public BaseRepository(EatEazeDataContext dataContext)
        {
            _eatEazeDataContext = dataContext;
        }

        public void AddItem(T item)
        {
            _eatEazeDataContext.Set<T>().Add(item);
            _eatEazeDataContext.SaveChanges();
        }

        public void AddItem(IEnumerable<T> items)
        {
            _eatEazeDataContext.Set<T>().AddRange(items);
            _eatEazeDataContext.SaveChanges();
        }

        public void DeleteItem(T item)
        {
            _eatEazeDataContext.Set<T>().Remove(item);
            _eatEazeDataContext.SaveChanges();
        }

        public void DeleteItem(IEnumerable<T> items)
        {
            _eatEazeDataContext.Set<T>().RemoveRange(items);
            _eatEazeDataContext.SaveChanges();
        }

        public IEnumerable<T> GetListOfItem()
        {
            return _eatEazeDataContext.Set<T>();
        }

        public void UpdateItem(T item)
        {
            _eatEazeDataContext.Update(item);
            _eatEazeDataContext.SaveChanges();
        }
    }
}

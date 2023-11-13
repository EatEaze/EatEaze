using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EatEaze.Data.Repositiories.RepositoriesImpls
{
    public class CategoriesRepository : ICategoryRepository
    {
        private EatEazeDataContext _eatEazeDataContext;

        public CategoriesRepository(EatEazeDataContext dataContext) // : base(dataContext)
        {
            _eatEazeDataContext = dataContext;  
        }

        public async Task AddItem(Category item)
        {
            await _eatEazeDataContext.Categories.AddAsync(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task AddItem(IEnumerable<Category> items)
        {
            await _eatEazeDataContext.Categories.AddRangeAsync(items);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task DeleteItem(Category item)
        {
            _eatEazeDataContext.Categories.Remove(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task DeleteItem(IEnumerable<Category> items)
        {
            _eatEazeDataContext.Categories.RemoveRange(items);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetListOfItem()
        {
            return await _eatEazeDataContext.Categories.ToListAsync();
        }

        public async Task UpdateItem(Category item)
        {
            _eatEazeDataContext.Update(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }
    }
}

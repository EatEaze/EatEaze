using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EatEaze.Data.Repositiories.RepositoriesImpls
{
    public class RestarauntsRepository : IRestarauntsRepository
    {
        private EatEazeDataContext _eatEazeDataContext;

        public RestarauntsRepository(EatEazeDataContext dataContext) // :  base(dataContext) 
        {
            _eatEazeDataContext = dataContext;
        }

        public async Task AddItem(Restaraunt item)
        {
            await _eatEazeDataContext.Restaraunts.AddAsync(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task AddItem(IEnumerable<Restaraunt> items)
        {
            await _eatEazeDataContext.Restaraunts.AddRangeAsync(items);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task DeleteItem(Restaraunt item)
        {
            _eatEazeDataContext.Restaraunts.Remove(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task DeleteItem(IEnumerable<Restaraunt> items)
        {
            _eatEazeDataContext.Restaraunts.RemoveRange(items);
            await _eatEazeDataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaraunt>> GetListOfItem()
        {
            return await _eatEazeDataContext.Restaraunts.ToListAsync();
        }

        public async Task<IEnumerable<Restaraunt>> GetRestarauntsByCities(Guid cityId)
        {
            var result = await _eatEazeDataContext.RestarauntsInCities.Where(c => c.CityId == cityId).ToListAsync() as IEnumerable<Restaraunt>;
            
            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        public async Task UpdateItem(Restaraunt item)
        {
            _eatEazeDataContext.Update(item);
            await _eatEazeDataContext.SaveChangesAsync();
        }
    }
}

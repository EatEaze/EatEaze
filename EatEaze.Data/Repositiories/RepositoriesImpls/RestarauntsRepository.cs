using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EatEaze.Data.Repositiories.RepositoriesImpls
{
    public class RestarauntsRepository : BaseRepository<Restaraunt>, IRestarauntsRepository
    {
        public RestarauntsRepository(EatEazeDataContext dataContext) : base(dataContext) 
        { }

        public async Task<IEnumerable<Restaraunt>> GetRestarauntsByCities(Guid cityId)
        {
            var result = await _eatEazeDataContext.RestarauntsInCities.Where(c => c.CityId == cityId).ToListAsync() as IEnumerable<Restaraunt>;
            
            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }
    }
}

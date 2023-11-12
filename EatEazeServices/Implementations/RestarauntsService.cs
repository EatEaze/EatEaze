using EatEaze.Data.Entities;
using EatEazeServices.Interfaces;

namespace EatEaze.Services.Implementations
{
    public class RestarauntsService : IRestarauntsService
    {

        public Task<IEnumerable<Restaraunt>> GetRestaraunts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Restaraunt>> GetRestaraunts(Guid CityId)
        {
            throw new NotImplementedException();
        }
    }
}

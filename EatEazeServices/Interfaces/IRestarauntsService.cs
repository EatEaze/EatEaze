using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface IRestarauntsService
    {
        public Task<IEnumerable<Restaraunt>> GetRestaraunts();
        public Task<IEnumerable<Restaraunt>> GetRestaraunts(Guid CityId);
    }
}

using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface IRestarauntsService
    {
        public IEnumerable<Restaraunt> GetRestaraunts();
        public IEnumerable<Restaraunt> GetRestaraunts(Guid CityId);
    }
}

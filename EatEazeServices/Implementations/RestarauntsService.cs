using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using EatEazeServices.Interfaces;

namespace EatEaze.Services.Implementations
{
    public class RestarauntsService : IRestarauntsService
    {
        private IRestarauntsRepository _restarauntsRepository;

        public RestarauntsService(IRestarauntsRepository restarauntsRepository)
        {
            _restarauntsRepository = restarauntsRepository;    
        }

        public async Task<IEnumerable<Restaraunt>> GetRestaraunts()
        {
            return await _restarauntsRepository.GetListOfItem();
        }

        public async Task<IEnumerable<Restaraunt>> GetRestaraunts(Guid CityId)
        {
            return await _restarauntsRepository.GetRestarauntsByCities(CityId);
        }

        public async Task<IEnumerable<Restaraunt>> GetRestarauntsByCategory(Guid categoryId)
        {
            return await _restarauntsRepository.GetRestarauntsByCategories(categoryId);
        }
    }
}

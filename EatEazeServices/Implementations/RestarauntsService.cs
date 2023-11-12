using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesImpls;
using EatEazeServices.Interfaces;

namespace EatEaze.Services.Implementations
{
    public class RestarauntsService : IRestarauntsService
    {
        private RestarauntsRepository _restarauntsRepository;

        public RestarauntsService(RestarauntsRepository restarauntsRepository)
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
    }
}

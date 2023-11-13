
using EatEaze.Data.Entities;

namespace EatEaze.Data.Repositiories.RepositoriesInterfaces
{
    public interface IRestarauntsRepository : IBaseRepository<Restaraunt>
    {
        Task<IEnumerable<Restaraunt>> GetRestarauntsByCities(Guid cityId);
    }
}

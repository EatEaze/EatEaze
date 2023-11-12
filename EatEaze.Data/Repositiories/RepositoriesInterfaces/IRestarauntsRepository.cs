
using EatEaze.Data.Entities;

namespace EatEaze.Data.Repositiories.RepositoriesInterfaces
{
    public interface IRestarauntsRepository 
    {
        Task<IEnumerable<Restaraunt>> GetRestarauntsByCities(Guid cityId);
    }
}

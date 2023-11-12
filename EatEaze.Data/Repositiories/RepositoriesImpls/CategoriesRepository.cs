using EatEaze.Data.DataContext;
using EatEaze.Data.Entities;

namespace EatEaze.Data.Repositiories.RepositoriesImpls
{
    public class CategoriesRepository : BaseRepository<Category>
    {
        public CategoriesRepository(EatEazeDataContext dataContext) : base(dataContext)
        {
        }
    }
}

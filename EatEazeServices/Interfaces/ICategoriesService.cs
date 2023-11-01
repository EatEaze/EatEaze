using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface ICategoriesService
    {
        public IEnumerable<Category> GetCategories();
    }
}

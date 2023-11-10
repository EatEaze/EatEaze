using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface ICategoriesService
    {
        public Task<IEnumerable<Category>> GetCategories();
        public Task<Category> GetCategory(Guid categoryId);
        public Task AddCategory(Category category);
        public Task RemoveCategory(Category category);
        public Task UpdateCategory(Category category);
    }
}

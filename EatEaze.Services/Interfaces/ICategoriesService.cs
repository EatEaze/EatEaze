using EatEaze.Data.Entities;

namespace EatEazeServices.Interfaces
{
    public interface ICategoriesService
    {
        public IEnumerable<Category> GetCategories();
        public Category GetCategory(Guid categoryId);
        public void AddCategory(Category category);
        public void RemoveCategory(Category category);
        public void UpdateCategory(Category category);
    }
}

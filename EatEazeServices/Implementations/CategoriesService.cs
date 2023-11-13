using EatEaze.Data.Entities;
using EatEaze.Data.Repositiories.RepositoriesInterfaces;
using EatEazeServices.Interfaces;

namespace EatEaze.Services.Implementations
{
    public class CategoriesService : ICategoriesService
    {
        private ICategoryRepository _categoriesRepository;

        public CategoriesService(ICategoryRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task AddCategory(Category category)
        {
            await _categoriesRepository.AddItem(category);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _categoriesRepository.GetListOfItem();
            return categories;
        }

        public Task<Category> GetCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

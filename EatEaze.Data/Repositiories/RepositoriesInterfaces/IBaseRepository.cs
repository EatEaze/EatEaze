namespace EatEaze.Data.Repositiories.RepositoriesInterfaces
{
    public interface IBaseRepository<T>
    {
        public Task AddItem(T item);

        public Task AddItem(IEnumerable<T> items);

        public Task DeleteItem(T item);

        public Task DeleteItem(IEnumerable<T> items);

        public Task<IEnumerable<T>> GetListOfItem();

        public Task UpdateItem(T item);

    }
}

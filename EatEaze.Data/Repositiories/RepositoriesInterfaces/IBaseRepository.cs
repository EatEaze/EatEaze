namespace EatEaze.Data.Repositiories.RepositoriesInterfaces
{
    public interface IBaseRepository<T>
    {
        public void AddItem(T item);

        public void AddItem(IEnumerable<T> items);

        public void DeleteItem(T item);

        public void DeleteItem(IEnumerable<T> items);

        public IEnumerable<T> GetListOfItem();

        public void UpdateItem(T item);

    }
}

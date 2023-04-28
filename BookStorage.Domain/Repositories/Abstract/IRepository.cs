namespace BookStorage.Domain.Repositories.Abstract
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Delete(T item, int index);
        T[] GetAll();
        int Count();
    }
}
using BookStorage.Domain.Models;
using BookStorage.Domain.Repositories.Abstract;

namespace BookStorage.Domain.Repositories.Concreate.Memory
{
    public class MemoryERepository : IERepository
    {
        private readonly EBook[] ebooks;
        int count;

        public MemoryERepository()
        {
            ebooks = new EBook[100];
            count = 0;
        }

        public void Add(EBook eBook)
        {
            ebooks[count++] = eBook;
        }
        
        public void Delete(EBook eBook, int index)
        {
        }
        public int Count() => count;

        public EBook[] GetAll() => ebooks;
    }
}
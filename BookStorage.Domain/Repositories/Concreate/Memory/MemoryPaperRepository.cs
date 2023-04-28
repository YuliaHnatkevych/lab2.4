using BookStorage.Domain.Models;
using BookStorage.Domain.Repositories.Abstract;

namespace BookStorage.Domain.Repositories.Concreate.Memory
{
    internal class MemoryPaperRepository : IPaperRepository
    {
        private readonly PaperBook[] paperbooks;
        int count;

        public MemoryPaperRepository()
        {
            paperbooks = new PaperBook[100];
            count = 0;
        }
        public void Add(PaperBook car)
        {
            throw new System.NotImplementedException();
        }
        
        public void Delete(PaperBook car, int index)
        {
        }
        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public PaperBook[] GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
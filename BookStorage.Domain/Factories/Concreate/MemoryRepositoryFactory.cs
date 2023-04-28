using BookStorage.Domain.Factories.Abstract;
using BookStorage.Domain.Repositories.Abstract;
using BookStorage.Domain.Repositories.Concreate.Memory;

namespace BookStorage.Domain.Factories.Concreate
{
    internal class MemoryRepositoryFactory : IRepositoryFactory
    {
        public IERepository GetERepository()
        {
            return new MemoryERepository();
        }

        public IPaperRepository GetPaperRepository()
        {
            return new MemoryPaperRepository();
        }
    }
}
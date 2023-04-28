using BookStorage.Domain.Factories.Abstract;
using BookStorage.Domain.Repositories.Abstract;
using BookStorage.Domain.Repositories.Concreate.Mock;

namespace BookStorage.Domain.Factories.Concreate
{
    internal class MockRepositoryFactory : IRepositoryFactory
    {
        public IERepository GetERepository()
        {
            return new MockERepository();
        }

        public IPaperRepository GetPaperRepository()
        {
            return new MockPaperRepository();
        }
    }
}
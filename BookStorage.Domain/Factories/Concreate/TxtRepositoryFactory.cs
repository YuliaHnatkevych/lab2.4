using BookStorage.Domain.Factories.Abstract;
using BookStorage.Domain.Repositories.Abstract;
using BookStorage.Domain.Repositories.Concreate.Txt;

namespace BookStorage.Domain.Factories.Concreate
{
    internal class TxtRepositoryFactory : IRepositoryFactory
    {
        public IERepository GetERepository()
        {
            return new TxtERepository();
        }

        public IPaperRepository GetPaperRepository()
        {
            return new TxtPaperRepository();
        }
    }
}
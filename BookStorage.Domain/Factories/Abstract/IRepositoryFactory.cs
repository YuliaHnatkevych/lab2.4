using BookStorage.Domain.Models;
using BookStorage.Domain.Repositories.Abstract;

namespace BookStorage.Domain.Factories.Abstract
{
    public interface IRepositoryFactory
    {
        IERepository GetERepository();
        IPaperRepository GetPaperRepository();
    }
}
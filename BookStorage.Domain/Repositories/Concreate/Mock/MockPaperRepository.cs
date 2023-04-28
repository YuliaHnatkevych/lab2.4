using BookStorage.Domain.Models;
using BookStorage.Domain.Repositories.Abstract;

namespace BookStorage.Domain.Repositories.Concreate.Mock
{
    internal class MockPaperRepository : IPaperRepository
    {
        public void Add(PaperBook car)
        {
            throw new System.NotImplementedException();
        }
        
        public void Delete(PaperBook car, int index)
        {
            throw new System.NotImplementedException();
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
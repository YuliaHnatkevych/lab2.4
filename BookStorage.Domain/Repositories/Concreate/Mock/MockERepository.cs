using BookStorage.Domain.Models;
using BookStorage.Domain.Repositories.Abstract;

namespace BookStorage.Domain.Repositories.Concreate.Mock
{
    internal class MockERepository : IERepository
    {
        private readonly EBook[] ebooks;
        int count;

        public MockERepository()
        {
            ebooks = new EBook[]
            {
                new EBook { Name = "gatsby", Publisher = "Skott Fitzgerald", Year = 2023},
                new EBook { Name = "misery", Publisher = "Stephen King", Year = 2022},
                new EBook { Name = "chainsaw", Publisher = "Aki Hayakawa", Year = 2021},
                new EBook { Name = "it", Publisher = "Stephen King", Year = 1992}
            };

            count = 4;
        }

        public void Add(EBook eBook)
        {
            
        }
        
        public void Delete(EBook eBook, int index)
        {
            
        }

        public int Count() => count;

        public EBook[] GetAll() => ebooks;
    }
}
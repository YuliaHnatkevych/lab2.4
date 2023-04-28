using BookStorage.Domain.Convertors.Txt;
using BookStorage.Domain.Models;
using BookStorage.Domain.Repositories.Abstract;

namespace BookStorage.Domain.Repositories.Concreate.Txt
{
    internal class TxtERepository : TxtBaseRepository<EBook>, IERepository
    {
        public TxtERepository() : base(@"C:/Users/gnatk/OneDrive/Desktop/Uni-Programming/2course/Practice/Task_2.3/BookStorage.Domain/Data/Txt/ebooks.txt", 
            new ETxtConvertor())
        { }
    }
}
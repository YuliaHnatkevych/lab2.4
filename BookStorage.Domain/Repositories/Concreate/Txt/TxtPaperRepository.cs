using BookStorage.Domain.Convertors.Txt;
using BookStorage.Domain.Models;
using BookStorage.Domain.Repositories.Abstract;

namespace BookStorage.Domain.Repositories.Concreate.Txt
{
    internal class TxtPaperRepository : TxtBaseRepository<PaperBook>, IPaperRepository
    {
        public TxtPaperRepository() : base(@"C:/Users/gnatk/OneDrive/Desktop/Uni-Programming/2course/Practice/Task_2.3/BookStorage.Domain/Data/Txt/paperbooks.txt", 
            new PaperTxtConvertor())
        { }
    }
}
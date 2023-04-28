using System;
using BookStorage.Domain.Models;

namespace BookStorage.Domain.Convertors.Txt
{
    internal class PaperTxtConvertor : ITxtConvertor<PaperBook>
    {
        private char separator = ',';

        public PaperBook Convert(string line)
        {
            Console.WriteLine(line);
            var paperBookParts = line.Split(separator);
            return new PaperBook
            {
                Name = paperBookParts[0],
                Publisher = paperBookParts[1],
                Year = System.Convert.ToInt32(paperBookParts[2]),
                NumberOfPages = System.Convert.ToInt32(paperBookParts[3]),
                Format = paperBookParts[4],
                Weight = System.Convert.ToSingle(paperBookParts[5])
            };
        }

        public string Convert(PaperBook paperBook)
        {
            return $"{paperBook.Name}{separator}{paperBook.Publisher}{separator}{paperBook.Year}{separator}" +
                   $"{paperBook.NumberOfPages}" +
                   $"{separator}{paperBook.Format}{separator}{paperBook.Weight}";
        }
    }
}
using System;
using BookStorage.Domain.Models;

namespace BookStorage.Domain.Convertors.Txt
{
    internal class ETxtConvertor : ITxtConvertor<EBook>
    {
        private char separator = ',';

        public EBook Convert(string line)
        {
            Console.WriteLine(line);
            var eBookParts = line.Split(separator);
            return new EBook
            {
                Name = eBookParts[0],
                Publisher = eBookParts[1],
                Year = System.Convert.ToInt32(eBookParts[2]),
                NumberOfPages = System.Convert.ToInt32(eBookParts[3]),
                LinkOnBook = eBookParts[4],
                BookFormat = eBookParts[5]
                
            };
        }

        public string Convert(EBook eBook)
        {
            return $"{eBook.Name}{separator}{eBook.Publisher}{separator}{eBook.Year}{separator}{eBook.NumberOfPages}" +
                   $"{separator}{eBook.LinkOnBook}{separator}{eBook.BookFormat}";
        }
    }
}
using BookStorage.Domain.Exceptions;

namespace BookStorage.Domain.Models
{
    public class EBook
    {

        public string Name { get; set; }
        public string Publisher { get; set; }
        private int _year;
        public int NumberOfPages { get; set; }
        public string LinkOnBook { get; set; }
        public string BookFormat { get; set; }
        // public string Synopsis { get; set; }
        public int Year
        {
            get 
            { 
                return _year;
            }
            set
            {
                if (value < 0)
                    throw new ModelStateException("Year is negative");
                _year = value;
            }
        }
        // public override string ToString() => string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6}", Name, Publisher, 
        //     Year, NumberOfPages, LinkOnBook, BookFormat, Synopsis);
    }
}
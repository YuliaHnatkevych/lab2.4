using BookStorage.Domain.Exceptions;

namespace BookStorage.Domain.Models
{
    public class PaperBook
    {
        public string Name { get; set; }
        public override string ToString() => $"{Name}";
        public string Publisher { get; set; }
        private int _year;
        public int NumberOfPages { get; set; }
        public string Format { get; set; }
        public float Weight { get; set; }
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
    }
}
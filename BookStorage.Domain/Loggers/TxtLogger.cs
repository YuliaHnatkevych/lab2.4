using System;
using System.IO;

namespace BookStorage.Domain.Loggers
{
    public class TxtLogger
    {
        public void LogError(string error)
        {
            using (var sw = new StreamWriter("C:/Users/gnatk/OneDrive/Desktop/Uni-Programming/2course/Practice" +
                                             "/Task_2.3/BookStorage.Domain/Loggersloggers.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + " " + error);
            }
        }

        private TxtLogger() { }

        private static TxtLogger _instance;
        public static TxtLogger GetLogger()
        {
            if (_instance == null)
                _instance = new TxtLogger();

            return _instance;
        }

    }
}
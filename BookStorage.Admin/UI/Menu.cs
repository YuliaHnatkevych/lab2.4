using System;
using BookStorage.Domain.Enums;
using BookStorage.Domain.Factories;
using BookStorage.Domain.Loggers;
using BookStorage.Domain.Models;
using BookStorage.Domain.Repositories.Abstract;

namespace BookStorage.Admin.UI
{
    internal class Menu
    {
        private readonly IERepository ebookRepository;
        private int index = 0;

        public Menu()
        {
            var factoryProvider = new FactoryProvider(FactoryType.Txt);
            var factory = factoryProvider.GetRepositoryFactory();

            ebookRepository = factory.GetERepository();
        }

        public void ShowMenu()
        {
            Console.WriteLine("~~ Welcome to Book Storage Admin ~~");

            while (ShowMenuOnce())
            { }

            Console.WriteLine("~ End ~");
        }

        private bool ShowMenuOnce()
        {
            Console.WriteLine("\n1 - Add new book." +
                              "\n2 - Print all books." +
                              "\n0 - Exit." +
                              "\nSelect option >> ");
            string userInput = Console.ReadLine();

            try
            {
                switch (userInput)
                {
                    case "1":
                        AddNewEBook();
                        return true;
                    case "2":
                        PrintAllEBooks();
                        return true;
                    case "0":
                        return false;
                    default:
                        return true;
                }
            }
            catch (Exception ex)
            {
                TxtLogger.GetLogger().LogError(ex.Message);
                Console.WriteLine($"Opps..something goes wrong...");
                return true;
            }
        }

        private void PrintAllEBooks()
        {
            var ebooks = ebookRepository.GetAll();

            for (int i = 0; i < ebookRepository.Count(); i++)
            {
                Console.WriteLine("\n\tBook name >> " + ebooks[i].Name
                                                        + "\n\tBook publisher >>  " + ebooks[i].Publisher
                                                        + "\n\tYear of publishing the book >> " +
                                                        Convert.ToString(ebooks[i].Year));
                
            }
        }

        private void AddNewEBook()
        {
            Console.WriteLine("Enter book info:");
            
            Console.WriteLine("Enter name >> ");
            var name = Console.ReadLine();
            
            Console.WriteLine("Enter publisher >> ");
            var publisher = Console.ReadLine();
            
            Console.WriteLine("Enter year >> ");
            var year = Convert.ToInt32(Console.ReadLine());

            ebookRepository.Add(new EBook 
            {
                Name = name,
                Publisher = publisher,
                Year = year
            });
            
            ebookRepository.Delete(new EBook 
            {
                Name = name,
                Publisher = publisher,
                Year = year
            }, index);
        }
    }
}
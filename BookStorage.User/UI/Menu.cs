using System;
using BookStorage.Domain.Enums;
using BookStorage.Domain.Factories;
using BookStorage.Domain.Loggers;
using BookStorage.Domain.Models;
using BookStorage.Domain.Repositories.Abstract;

namespace BookStorage.User.UI
{
    internal class Menu
    {
        private readonly IERepository ebookRepository;

        public Menu()
        {
            var factoryProvider = new FactoryProvider(FactoryType.Txt);
            var factory = factoryProvider.GetRepositoryFactory();

            ebookRepository = factory.GetERepository();
        }

        public void ShowMenu()
        {
            Console.WriteLine("~~ Welcome to Book Storage User ~~");

            while (ShowMenuOnce())
            { }

            Console.WriteLine("~ End ~");
        }

        private bool ShowMenuOnce()
        {
            Console.WriteLine("\n1 - Print all books." +
                              "\n0 - Exit." +
                              "\nSelect option >> ");
            string userInput = Console.ReadLine();

            try
            {
                switch (userInput)
                {
                    case "1":
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
    }
    }
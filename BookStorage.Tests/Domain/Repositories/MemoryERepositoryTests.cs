using System;
using BookStorage.Domain.Exceptions;
using BookStorage.Domain.Models;
using NUnit.Framework;
using BookStorage.Domain.Repositories.Concreate.Memory;

namespace BookStorage.Tests.Domain.Repositories
{
    [TestFixture]
    public class MemoryERepositoryTests
    {
        [Test]
        public void TestAddEBook_ReturnsAddedEBook()
        {
            //arrange - підготовка даних
            var memoryEBookRepository = new MemoryERepository();
            var ebookToAdd = new EBook
            {
                Name = "Name",
                Publisher = "Publisher"
            };
            //act - дія
            memoryEBookRepository.Add(ebookToAdd);

            //assert -виправдання очікувань
            var actualAddedEBook = memoryEBookRepository.GetAll()[memoryEBookRepository.Count() - 1];
            Assert.AreEqual(ebookToAdd, actualAddedEBook);
        }

        [Test]
        public void TestAddEBook_ThrowsException()
        {
            //arrange - підготовка даних
            var memoryEBookRepository = new MemoryERepository();

            //assert -виправдання очікувань
            Assert.Throws<ModelStateException>(() =>
            {
                memoryEBookRepository.Add(new EBook
                {
                    Year = -10
                });
            });
        }
    }
}
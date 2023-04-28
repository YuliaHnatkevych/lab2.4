using System;
using BookStorage.Domain.Enums;
using BookStorage.Domain.Factories.Abstract;
using BookStorage.Domain.Factories.Concreate;

namespace BookStorage.Domain.Factories
{
    public class FactoryProvider
    {
        private FactoryType type;

        public FactoryProvider(FactoryType type)
        {
            this.type = type;
        }

        public IRepositoryFactory GetRepositoryFactory()
        {
            if (type == FactoryType.Memory)
                return new MemoryRepositoryFactory();
            else if (type == FactoryType.Mock)
                return new MockRepositoryFactory();
            else if (type == FactoryType.Txt)
                return new TxtRepositoryFactory();
            else
                throw new Exception("Wrong factory type");
        }
    }
}
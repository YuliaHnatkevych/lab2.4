using System;

namespace BookStorage.Domain.Exceptions
{
    public class ModelStateException : Exception
    {
        public ModelStateException(string message) : base(message) // call ctor of the base class
        { }

        override public string Message
        {
            get
            {
                return "Model State Error: " + base.Message;
            }
        }
    }
}
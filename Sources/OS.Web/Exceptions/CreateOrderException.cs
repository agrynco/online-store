using System;

namespace OS.Web.Exceptions
{
    public class CreateOrderException : Exception
    {
        public CreateOrderException()
        {
        }

        public CreateOrderException(string message) : base(message)
        {
        }

        public CreateOrderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
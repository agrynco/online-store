using System;
using System.Runtime.Serialization;

namespace OS.Dependency
{
    public class OnlineStoreDependencyException : Exception
    {
        public OnlineStoreDependencyException()
        {
        }

        public OnlineStoreDependencyException(string message) : base(message)
        {
        }

        public OnlineStoreDependencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OnlineStoreDependencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
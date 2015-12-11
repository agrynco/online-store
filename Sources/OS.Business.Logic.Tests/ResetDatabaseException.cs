using System;

namespace OS.Business.Logic.Tests
{
    public class ResetDatabaseException : Exception
    {
        public ResetDatabaseException()
        {
        }

        public ResetDatabaseException(string message) : base(message)
        {
        }
    }
}
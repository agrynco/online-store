using System;

namespace OS.Repositories.Tests
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
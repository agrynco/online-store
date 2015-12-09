using System;

namespace OS.Business.Logic.Exceptions
{
    public class ThereIsNoBrandWithNameException : BaseBusinessException
    {
        public ThereIsNoBrandWithNameException(string name) : base(String.Format("There is no Brand with Name = '{0}'", name))
        {
        }
    }
}
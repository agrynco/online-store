using System;

namespace OS.Business.Logic.Exceptions
{
    public class ThereIsNoCountryWithNameException : BaseBusinessException
    {
        public ThereIsNoCountryWithNameException(string name) : base(String.Format("There is no Country with Name = '{0}'", name))
        {
        }
    }
}
namespace OS.Business.Logic.Exceptions
{
    public class ThereIsNoCountryWithNameException : BaseBusinessException
    {
        public ThereIsNoCountryWithNameException(string name) : base($"There is no Country with Name = '{name}'")
        {
        }
    }
}
namespace OS.Business.Logic.Exceptions
{
    public class ThereIsNoBrandWithNameException : BaseBusinessException
    {
        public ThereIsNoBrandWithNameException(string name) : base($"There is no Brand with Name = '{name}'")
        {
        }
    }
}
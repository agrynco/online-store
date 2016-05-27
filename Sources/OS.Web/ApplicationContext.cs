using OS.Business.Domain;
using OS.Business.Logic;
using OS.Dependency;

namespace OS.Web
{
    public static class ApplicationContext
    {
        static ApplicationContext()
        {
            MainCurrency = DI.Resolve<CurrenciesBL>().GetMainCurrency();
        }

        public static Currency MainCurrency { get; set; }
    }
}
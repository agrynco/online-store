using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OS.Business.Domain;
using OS.Business.Logic;

namespace OS.Web.Controllers.Api
{
    [RoutePrefix("api/currencyrates")]
    public class CurrencyRatesController : BaseApiController
    {
        private readonly CurrencyRatesBL _currencyRatesBL;

        public CurrencyRatesController(CurrencyRatesBL currencyRatesBL)
        {
            _currencyRatesBL = currencyRatesBL;
        }

        [Route]
        public object Get()
        {
            List<CurrencyRate> currencyRates = _currencyRatesBL.GetAll();
            return new
                {
                    data = currencyRates.Select(currencyRate => new
                        {
                            currencyRate.Id,
                            Currency = $"{currencyRate.Currency.Name} ({currencyRate.Currency.Symbol})",
                            currencyRate.DateOfRate,
                            currencyRate.Rate
                        })
                };
        }
    }
}
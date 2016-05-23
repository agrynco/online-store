using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OS.Business.Domain;
using OS.Business.Logic;

namespace OS.Web.Controllers.Api
{
    [RoutePrefix("api/currencies")]
    public class CurrenciesController : BaseApiController
    {
        private readonly CurrenciesBL _currenciesBL;

        public CurrenciesController(CurrenciesBL currenciesBL)
        {
            _currenciesBL = currenciesBL;
        }

        [Route]
        public object Get()
        {
            List<Currency> currencies = _currenciesBL.GetAll();
            return new
                {
                    data = currencies.Select(currency => new
                        {
                            currency.Id,
                            currency.Name,
                            currency.Symbol,
                            currency.Code,
                            currency.CodeISO,
                            Country = currency.Country != null ? currency.Country.Name : "-",
                            currency.IsMain
                        })
                };
        }
    }
}
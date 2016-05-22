using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class CurrenciesBL
    {
        private readonly ICurrenciesRepository _currenciesRepository;

        public CurrenciesBL(ICurrenciesRepository currenciesRepository)
        {
            _currenciesRepository = currenciesRepository;
        }

        public List<Currency> GetAll()
        {
            return _currenciesRepository.GetAll(false).ToList();
        }
    }
}
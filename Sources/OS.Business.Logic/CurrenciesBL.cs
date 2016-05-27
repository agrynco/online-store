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

        public Currency Get(int id)
        {
            return _currenciesRepository.GetById(id);
        }

        public void Update(Currency currency)
        {
            _currenciesRepository.Update(currency);
        }

        public void Add(Currency currency)
        {
            _currenciesRepository.Add(currency);
        }

        public Currency GetMainCurrency()
        {
            return _currenciesRepository.GetMainCurrency();
        }
    }
}
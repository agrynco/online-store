using System;
using System.Collections.Generic;
using System.Linq;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.Business.Logic
{
    public class CurrencyRatesBL
    {
        private readonly ICurrencyRatesRepository _currencyRatesRepository;

        public CurrencyRatesBL(ICurrencyRatesRepository currencyRatesRepository)
        {
            _currencyRatesRepository = currencyRatesRepository;
        }

        public List<CurrencyRate> GetAll()
        {
            return _currencyRatesRepository.GetAll(false).ToList();
        }

        public CurrencyRate Get(int id)
        {
            return _currencyRatesRepository.GetById(id);
        }

        public CurrencyRate Update(CurrencyRate currencyRate)
        {
            _currencyRatesRepository.Update(currencyRate);
            return currencyRate;
        }

        public CurrencyRate Add(CurrencyRate currencyRate)
        {
            currencyRate.DateOfRate = DateTime.Now;
            return _currencyRatesRepository.Add(currencyRate);
        }
    }
}
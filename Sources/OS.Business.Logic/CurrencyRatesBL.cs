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
        private readonly IProductsRepository _productsRepository;

        public CurrencyRatesBL(ICurrencyRatesRepository currencyRatesRepository, IProductsRepository productsRepository)
        {
            _currencyRatesRepository = currencyRatesRepository;
            _productsRepository = productsRepository;
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
            _productsRepository.UpdatePricesInMainCurrency();
            return currencyRate;
        }

        public CurrencyRate Add(CurrencyRate currencyRate)
        {
            currencyRate.DateOfRate = DateTime.Now;
            CurrencyRate rate = _currencyRatesRepository.Add(currencyRate);
            _productsRepository.UpdatePricesInMainCurrency();

            return rate;
        }
    }
}
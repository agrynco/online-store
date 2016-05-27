using System;
using NUnit.Framework;
using OS.Business.Domain;
using OS.DAL.Abstract;
using OS.Dependency;

namespace OS.Repositories.Tests
{
    [TestFixture]
    public class CurrencyRatesRepositoryReadOnlyTests : BaseReadonlyRepositoryTests
    {
        [Test]
        public void GetActualRate_1()
        {
            //Arrange
            ResetDataBase();

            DateTime date = new DateTime(2016, 5, 5);
            ICurrencyRatesRepository currencyRatesRepository = DI.Resolve<ICurrencyRatesRepository>();

            //Act
            CurrencyRate currencyRate = currencyRatesRepository.GetActualRate(3, date);

            //Asserts
            Assert.That(currencyRate.Id, Is.EqualTo(3));
        }

        [Test]
        public void GetActualRate_2()
        {
            //Arrange
            ResetDataBase();

            DateTime date = DateTime.Now;
            ICurrencyRatesRepository currencyRatesRepository = DI.Resolve<ICurrencyRatesRepository>();

            //Act
            CurrencyRate currencyRate = currencyRatesRepository.GetActualRate(3, date);

            //Asserts
            Assert.That(currencyRate.Id, Is.EqualTo(1));
        }
    }
}
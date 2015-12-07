using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using OS.Business.Domain;
using OS.DAL.Abstract;

namespace OS.Business.Logic.Tests
{
    [TestFixture]
    public class CountriesBLTests
    {
        [Test]
        public void UpdateCountries_AllZerro()
        {
            //Arrange
            var countriesRepository = new Mock<ICountriesRepository>();
            countriesRepository.Setup(r => r.GetAll()).Returns(new List<Country>().AsQueryable());
            countriesRepository.Setup(r => r.Update(It.IsAny<Country>())).Callback((Country country) => {});
            countriesRepository.Setup(r => r.Add(It.IsAny<Country>())).Callback((Country country) => {});
            countriesRepository.Setup(r => r.Delete(It.IsAny<Country>())).Callback((Country country) => {});
            countriesRepository.Setup(r => r.GetAll()).Returns(new List<Country>().AsQueryable());
            
            CountriesBL countriesBL = new CountriesBL(countriesRepository.Object);

            //Act
            UpdateCountriesResult updateCountriesResult = countriesBL.UpdateCountries(new List<Country>());

            //Assert
            Assert.That(updateCountriesResult.Created.Count, Is.EqualTo(0));
            Assert.That(updateCountriesResult.Updated.Count, Is.EqualTo(0));
            Assert.That(updateCountriesResult.Deleted.Count, Is.EqualTo(0));
        }

        [Test]
        public void UpdateCountries_OneToCreate()
        {
            //Arrange
            var countriesRepository = new Mock<ICountriesRepository>();
            countriesRepository.Setup(r => r.GetAll()).Returns(new List<Country>().AsQueryable());
            countriesRepository.Setup(r => r.Add(It.IsAny<Country>())).Callback((Country country) => { });
            countriesRepository.Setup(r => r.Delete(It.IsAny<Country>())).Callback((Country country) => { });
            countriesRepository.Setup(r => r.GetAll()).Returns(new List<Country>().AsQueryable());

            CountriesBL countriesBL = new CountriesBL(countriesRepository.Object);

            //Act
            UpdateCountriesResult updateCountriesResult = countriesBL.UpdateCountries(new List<Country>(new []
                {
                    new Country
                        {
                            EnglishName = "Some Country"
                        }
                }));

            //Assert
            Assert.That(updateCountriesResult.Created.Count, Is.EqualTo(1));
            Assert.That(updateCountriesResult.Updated.Count, Is.EqualTo(0));
            Assert.That(updateCountriesResult.Deleted.Count, Is.EqualTo(0));
        }

        [Test]
        public void UpdateCountries_OneToUpdate()
        {
            //Arrange
            var countriesRepository = new Mock<ICountriesRepository>();
            countriesRepository.Setup(r => r.Add(It.IsAny<Country>())).Callback((Country country) => { });
            countriesRepository.Setup(r => r.Delete(It.IsAny<Country>())).Callback((Country country) => { });
            countriesRepository.Setup(r => r.GetAll()).Returns(new List<Country>(new[]
                {
                    new Country
                        {
                            EnglishName = "Some Country"
                        }
                }).AsQueryable());
            CountriesBL countriesBL = new CountriesBL(countriesRepository.Object);

            //Act
            UpdateCountriesResult updateCountriesResult = countriesBL.UpdateCountries(new List<Country>(new []
                {
                    new Country
                        {
                            EnglishName = "Some Country"
                        }
                }));

            //Assert
            Assert.That(updateCountriesResult.Created.Count, Is.EqualTo(0));
            Assert.That(updateCountriesResult.Updated.Count, Is.EqualTo(1));
            Assert.That(updateCountriesResult.Deleted.Count, Is.EqualTo(0));
        }

        [Test]
        public void UpdateCountries_OneToDelete()
        {
            //Arrange
            var countriesRepository = new Mock<ICountriesRepository>();
            countriesRepository.Setup(r => r.GetAll()).Returns(new List<Country>(new[]
                {
                    new Country
                        {
                            EnglishName = "Some Country"
                        }
                }).AsQueryable());
            CountriesBL countriesBL = new CountriesBL(countriesRepository.Object);

            //Act
            UpdateCountriesResult updateCountriesResult = countriesBL.UpdateCountries(new List<Country>());

            //Assert
            Assert.That(updateCountriesResult.Created.Count, Is.EqualTo(0));
            Assert.That(updateCountriesResult.Updated.Count, Is.EqualTo(0));
            Assert.That(updateCountriesResult.Deleted.Count, Is.EqualTo(1));
        }
    }
}
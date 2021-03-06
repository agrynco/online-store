﻿using System;
using System.Linq;
using NUnit.Framework;
using OS.Dependency;
using OS.Repositories.Tests;

namespace OS.Business.Logic.Tests
{
    [TestFixture]
    public class ProductsBLTests : BaseDbIntegrationTestFixture
    {
        [Test]
        public void CalculatePriceInTheMainCurrency()
        {
            //Arrange
            ResetDataBase();
            ProductsBL productsBL = DI.Resolve<ProductsBL>();

            //Act
            decimal actual = productsBL.CalculatePriceInTheMainCurrency(3, 100, new DateTime(2016, 5, 5));

            //Assert
            Assert.That(actual, Is.EqualTo(2564));
        }

        [Test]
        public void CalculatePriceInTheMainCurrency_WithMainCurrency()
        {
            //Arrange
            ResetDataBase();
            ProductsBL productsBL = DI.Resolve<ProductsBL>();

            //Act
            decimal actual = productsBL.CalculatePriceInTheMainCurrency(1, 100);

            //Assert
            Assert.That(actual, Is.EqualTo(100));
        }

        [Test]
        public void Delete_ShouldUnassignFromCtegories()
        {
            //Arrange
            ResetDataBase();
            ProductsBL productsBL = DI.Resolve<ProductsBL>();

            //Act
            productsBL.Delete(1);

            //Assert
            bool isDeleted = EntityFrameworkDbContext.Products.Where(product => product.Id == 1).Select(product => product.IsDeleted).Single();
            Assert.That(isDeleted, Is.True);
        }

        [Test]
        public void DeletePermanently()
        {
            //Arrange
            ResetDataBase();
            ProductsBL productsBL = DI.Resolve<ProductsBL>();

            //Act
            productsBL.DeletePermanently(1);

            //Asserts
        }
    }
}
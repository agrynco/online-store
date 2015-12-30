﻿using System.Collections.Generic;
using NUnit.Framework;
using OS.Business.Domain;
using OS.DAL.EF.Repositories;
using OS.Dependency;

namespace OS.Repositories.Tests
{
    [TestFixture]
    public class ProductCategoriesRepositoryReadOnlyTests : BaseReadonlyRepositoryTests
    {
        [Test]
        public void GetParentCategories()
        {
            //Arrange
            ProductCategoriesRepository productCategoriesRepository = DI.Resolve<ProductCategoriesRepository>();

            //Act
            IList<ProductCategory> productCategories = productCategoriesRepository.GetParentCategories(13);

            //Assert
            Assert.That(productCategories.Count, Is.EqualTo(2));
            Assert.That(productCategories[0].Id, Is.EqualTo(12));
            Assert.That(productCategories[1].Id, Is.EqualTo(7));
        }
    }
}
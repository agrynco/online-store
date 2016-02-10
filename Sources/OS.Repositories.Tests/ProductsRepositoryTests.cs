using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OS.Business.Domain;
using OS.DAL.EF.Repositories;
using OS.Dependency;

namespace OS.Repositories.Tests
{
    [TestFixture]
    public class ProductsRepositoryReadOnlyTests : BaseReadonlyRepositoryTests
    {
        [Test]
        public void GeProducts_ByName()
        {
            //Arrange
            ProductsRepository productsRepository = DI.Resolve<ProductsRepository>();
            ProductsFilter filter = new ProductsFilter
            {
                Text = "об"
            };

            //Act
            List<Product> products = productsRepository.Get(filter).ToList();

            //Assert
            Assert.That(products.Count, Is.EqualTo(8));
        }

        [Test]
        public void GeProducts_ByParentId()
        {
            //Arrange
            ProductsRepository productsRepository = DI.Resolve<ProductsRepository>();
            ProductsFilter filter = new ProductsFilter
            {
                ParentId = 5
            };

            //Act
            List<Product> products = productsRepository.Get(filter).ToList();

            //Assert
            Assert.That(products.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetProducts_ByParentIdAndByName()
        {
            //Arrange
            ProductsRepository productsRepository = DI.Resolve<ProductsRepository>();
            ProductsFilter filter = new ProductsFilter
            {
                ParentId = 5,
                Text = "об"
            };

            //Act
            List<Product> products = productsRepository.Get(filter).ToList();

            //Assert
            Assert.That(products.Count, Is.EqualTo(1));
        }
    }
}
using NUnit.Framework;
using OS.Dependency;
using OS.Repositories.Tests;

namespace OS.Business.Logic.Tests
{
    public class ProductCategoriesBLTests : BaseDbIntegrationTestFixture
    {
        [Test]
        public void DeleteById()
        {
            //Arrange
            ResetDataBase();
            ProductCategoriesBL target = DI.Resolve<ProductCategoriesBL>();

            //Act
            target.Delete(37);

            //Asserts
            Assert.That(target.GetById(37).IsDeleted);
            Assert.That(target.GetById(38).IsDeleted);
            Assert.That(target.GetById(39).IsDeleted);
            Assert.That(target.GetById(40).IsDeleted);
            Assert.That(target.GetById(41).IsDeleted);
        }

        [Test]
        public void SetPublish()
        {
            //Arrange
            ResetDataBase();
            ProductCategoriesBL target = DI.Resolve<ProductCategoriesBL>();

            //Act
            target.SetPublish(37, false);

            //Asserts
            Assert.That(!target.GetById(37).Publish);
            Assert.That(!target.GetById(38).Publish);
            Assert.That(!target.GetById(39).Publish);
            Assert.That(!target.GetById(40).Publish);
            Assert.That(!target.GetById(41).Publish);
        }
    }
}
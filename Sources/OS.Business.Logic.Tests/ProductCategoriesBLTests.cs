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
            ProductsBL productsBl = DI.Resolve<ProductsBL>();

            //Act
            target.SetPublish(65, false);

            //Asserts
            Assert.That(!target.GetById(65).Publish);
            Assert.That(!productsBl.GetById(86).Publish);
            Assert.That(!productsBl.GetById(87).Publish);
            Assert.That(!productsBl.GetById(88).Publish);
            Assert.That(!productsBl.GetById(89).Publish);
            Assert.That(!productsBl.GetById(90).Publish);
            Assert.That(!productsBl.GetById(91).Publish);
            Assert.That(!productsBl.GetById(92).Publish);
            Assert.That(!productsBl.GetById(93).Publish);
            Assert.That(!productsBl.GetById(95).Publish);
        }
    }
}
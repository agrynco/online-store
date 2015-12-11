using System.Linq;
using NUnit.Framework;
using OS.Dependency;

namespace OS.Business.Logic.Tests
{
    [TestFixture]
    public class ProductsBLTests : BaseDbIntegrationTestFixture
    {
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
    }
}
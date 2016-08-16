using NUnit.Framework;
using OS.Business.Domain;
using OS.Dependency;
using OS.Repositories.Tests;

namespace OS.Business.Logic.Tests
{
    [TestFixture]
    public class ProductPhotosBLTests : BaseDbIntegrationTestFixture
    {
        [Test]
        public void ApplyWaterMark()
        {
            //Arrange
            ResetDataBase();
            PhotosBL target = DI.Resolve<PhotosBL>();

            //Act
            Photo photo = target.ApplyWaterMark(18, "test");

            //Asserts
            Assert.That(photo.WaterMarked.Data.Length > 0);
        }

        [Test]
        public void GetById()
        {
            //Arrange
            PhotosBL target = DI.Resolve<PhotosBL>();

            //Act
            Photo photo = target.GetById(1);

            //Asserts
            Assert.That(photo.WaterMarked, !Is.Null);
        }
    }
}
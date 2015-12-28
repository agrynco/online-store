using NUnit.Framework;
using OS.Business.Domain;
using OS.Dependency;
using OS.Repositories.Tests;

namespace OS.Business.Logic.Tests
{
    [TestFixture]
    public class ContentContentTypesBLTests : BaseDbIntegrationTestFixture
    {
        [Test]
        public void Get_ShouldReturnEntity()
        {
            //Arrange
            ResetDataBase();
            ContentContentTypesBL contentContentTypesBL = DI.Resolve<ContentContentTypesBL>();

            //Act
            ContentContentType contentContentType = contentContentTypesBL.Get("image/png");

            //Assert
            Assert.That(contentContentType, !Is.Null);
        } 
    }
}
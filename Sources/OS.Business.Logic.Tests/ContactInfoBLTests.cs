using NUnit.Framework;
using OS.Business.Domain;
using OS.Dependency;
using OS.Repositories.Tests;

namespace OS.Business.Logic.Tests
{
    [TestFixture]
    public class ContactInfoBLTests : BaseDbIntegrationTestFixture
    {
        [Test]
        public void Get_ShouldReturnNotNull()
        {
            //Arrange
            ContactInfoBL contactInfoBl = DI.Resolve<ContactInfoBL>();

            //Act
            ContactInfo info = contactInfoBl.Get();
            
            //Assert
            Assert.IsNotNull(info);
        }
    }
}
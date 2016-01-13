using NUnit.Framework;

namespace OS.Common.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void Trunc()
        {
            //Arrange

            //Act
            string actual = "Some long string".Trunc(10);

            //Assert
            Assert.That(actual, Is.EqualTo("Some long"));
        }
    }
}
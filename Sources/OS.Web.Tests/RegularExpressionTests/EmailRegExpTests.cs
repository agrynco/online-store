using System.Text.RegularExpressions;
using NUnit.Framework;

namespace OS.Web.Tests.RegularExpressionTests
{
    [TestFixture]
    public class EmailRegExpTests
    {
        [Test]
        public void Validate()
        {
            //Arrange
            Regex regex = new Regex(Constants.RegularExpressions.EMAIL);

            //Act


            //Asserts
            Assert.That(regex.Match("abcdefghixyz@example1.com").Success);
            Assert.That(regex.Match("abc.\"defghi\".xyz@example-1.com").Success);
            Assert.That(regex.Match("niceandsimple@example.com").Success);
            Assert.That(regex.Match("very.common@example.com").Success);
            Assert.That(regex.Match("disposable.style.email.with+symbol@example.com").Success);
            Assert.That(regex.Match("other.email-with-dash@example.com").Success);

            Assert.That(regex.Match("jsmith@example.org").Success);
            Assert.That(regex.Match("jsmith@[192.168.2.1]").Success);
        }
    }
}
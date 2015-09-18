#region Usings
using NUnit.Framework;
#endregion

namespace OS.Common.Tests
{
    [TestFixture]
    public class ConnectionStringEncoderTests
    {
        [Test]
        public void Encode()
        {
            const string CONNECTION_STRING = "Data Source=OnlineStoreDbSrv;Initial Catalog=OnlineStore;Persist Security Info=True;User ID=sa;Password=sa;";

            string actual = ConnectionStringEncoder.Encode(CONNECTION_STRING);

            Assert.That(actual, Is.EqualTo("Data Source=OnlineStoreDbSrv;Initial Catalog=OnlineStore;Persist Security Info=True;User ID=***;Password=***;"));
        }
    }
}
using System.Net;
using System.Net.Mail;
using NUnit.Framework;
using OS.Business.Logic.Mailing;
using OS.Configuration;

namespace OS.Business.Logic.Tests
{
    [TestFixture]
    public class MailServiceTests
    {
        [Test]
        public void Send()
        {
            //Arrange
            MailService target = new MailService(ApplicationSettings.Instance.MailServiceSettings.Host,
                ApplicationSettings.Instance.MailServiceSettings.Port,
                ApplicationSettings.Instance.MailServiceSettings.EnableSsl,
                new NetworkCredential
                    {
                        UserName = ApplicationSettings.Instance.MailServiceSettings.FromAddress,
                        Password = ApplicationSettings.Instance.MailServiceSettings.FromPassword
                    });

            //Act
            target.Send(new MailMessage
                {
                    Body = "Test",
                    To = {ApplicationSettings.Instance.MailServiceSettings.FromAddress},
                    From = new MailAddress(ApplicationSettings.Instance.MailServiceSettings.FromAddress, "OnlineStoreTest"),
                    Subject = "Test"
                });
        }
    }
}
using System;
using System.Net;
using System.Net.Mail;

namespace OS.Business.Logic.Mailing
{
    public class MailService : IMailService
    {
        private readonly SmtpClient _smtpClient;

        public MailService(string host, int port, bool enableSsl, NetworkCredential credentials)
        {
            _smtpClient = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enableSsl,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = credentials,
                    Timeout = 10000
                };
        }

        /// <exception cref="ArgumentNullException"><paramref name="message" /> is null.</exception>
        /// <exception cref="InvalidOperationException">This <see cref="T:System.Net.Mail.SmtpClient" /> has a <see cref="SmtpClient.SendAsync" /> call in progress.-or- <see cref="P:System.Net.Mail.MailMessage.From" /> is null.-or- There are no recipients specified in <see cref="P:System.Net.Mail.MailMessage.To" />, <see cref="P:System.Net.Mail.MailMessage.CC" />, and <see cref="P:System.Net.Mail.MailMessage.Bcc" /> properties.-or- <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod" /> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network" /> and <see cref="P:System.Net.Mail.SmtpClient.Host" /> is null.-or-<see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod" /> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network" /> and <see cref="P:System.Net.Mail.SmtpClient.Host" /> is equal to the empty string ("").-or- <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod" /> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.Network" /> and <see cref="P:System.Net.Mail.SmtpClient.Port" /> is zero, a negative number, or greater than 65,535.</exception>
        /// <exception cref="ObjectDisposedException">This object has been disposed.</exception>
        /// <exception cref="SmtpException">The connection to the SMTP server failed.-or-Authentication failed.-or-The operation timed out.-or-<see cref="P:System.Net.Mail.SmtpClient.EnableSsl" /> is set to true but the <see cref="P:System.Net.Mail.SmtpClient.DeliveryMethod" /> property is set to <see cref="F:System.Net.Mail.SmtpDeliveryMethod.SpecifiedPickupDirectory" /> or <see cref="F:System.Net.Mail.SmtpDeliveryMethod.PickupDirectoryFromIis" />.-or-<see cref="P:System.Net.Mail.SmtpClient.EnableSsl" /> is set to true, but the SMTP mail server did not advertise STARTTLS in the response to the EHLO command.</exception>
        /// <exception cref="SmtpFailedRecipientsException">The <paramref name="message" /> could not be delivered to one or more of the recipients in <see cref="P:System.Net.Mail.MailMessage.To" />, <see cref="P:System.Net.Mail.MailMessage.CC" />, or <see cref="P:System.Net.Mail.MailMessage.Bcc" />.</exception>
        public void Send(MailMessage message)
        {
            _smtpClient.Send(message);
        }

        public void Dispose()
        {
            _smtpClient.Dispose();
        }
    }
}
using System;
using System.Net.Mail;

namespace OS.Business.Logic.Mailing
{
    public interface IMailService : IDisposable
    {
        void Send(MailMessage message);
    }
}
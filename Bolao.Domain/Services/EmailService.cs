using Bolao.Domain.Interfaces.Services;
using System.Net;
using System.Net.Mail;

namespace Bolao.Domain.Services
{
    public sealed class EmailService : IEmailService
    {
        private const string HostUsername = "wellington_fernands@yahoo.com.br";
        private const string HostPassword = "764569wmf";

        public void SendEmail(string to, string subject, string message)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(HostUsername);
            email.To.Add(new MailAddress(to));
            email.Subject = subject;
            email.Body = message;

            SmtpClient client = new SmtpClient();
            client.Timeout = 100000;
            client.Credentials = new NetworkCredential(HostUsername, HostPassword);
            client.Send(email);
        }
    }
}
using System.Net;
using System.Net.Mail;

namespace Bolao.CrossCutting.Mail
{
	public sealed class EmailSmtp
	{
		// naoresponda@growups.com.br
		// senha: g013A15fcv#

		private const string _hostUsername = "wellington.m.fernandes@gmail.com";
		private const string _hostPassword = "764569Wmf";
		private const int _port = 587;
		private const string _smtp = "smtp.gmail.com";

		public void Send(string to, string subject, string message)
		{
			MailMessage email = new MailMessage();
			email.From = new MailAddress(_hostUsername, "Bolão Mil Grau!");
			email.To.Add(new MailAddress(to));
			email.Subject = subject;
			email.Body = message;
			email.Priority = MailPriority.High;

			using (SmtpClient client = new SmtpClient(_smtp, _port))
			{
				client.Credentials = new NetworkCredential(_hostUsername, _hostPassword);
				client.Timeout = 100000;
				client.EnableSsl = true;
				client.SendMailAsync(email);
			}
		}
	}
}
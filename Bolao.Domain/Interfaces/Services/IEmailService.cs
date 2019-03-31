using System;

namespace Bolao.Domain.Interfaces.Services
{
    public interface IEmailService
    {
		void SendEmailNewUser(string to, Guid token, string firstName);
		void SendEmailContact(string name, string email, string subject, string message);
	}
}
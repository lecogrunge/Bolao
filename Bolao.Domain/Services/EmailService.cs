using Bolao.CrossCutting.Mail;
using Bolao.Domain.Interfaces.Services;
using System;
using System.Reflection;

namespace Bolao.Domain.Services
{
	public sealed class EmailService : IEmailService
    {
		public void SendEmailContact(string name, string email, string subject, string message)
		{
			EmailSmtp smtp = new EmailSmtp();
            try
            {
                smtp.Send("wellington_fernands@yahoo.com.br", string.Format("[Contato] - {0}", subject), message);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }

        public void SendEmailForgotPassword(string to, Guid token)
        {
            throw new NotImplementedException();
        }

        public void SendEmailNewUser(string to, Guid token, string firstName)
        {
			string urlToken = "https://www.bolao.com.br?token=" + token;
			string emailContent = string.Format(@"
								Olá {0}, estamos quase lá!<br />
								Por favor click no link abaixo para confirmar seu cadastro. <br />
								<a href='{1}' target='_blank'>Confirmar cadastro</a><br /><br />!

								Caso você não tenha realizado nenhum cadastro em nosso sistema, favor desconsiderar esta mensagem.", firstName, urlToken);

			EmailSmtp smtp = new EmailSmtp();

            try
            {
                smtp.Send(to, "Confirmação de Cadastro", emailContent);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }
    }
}
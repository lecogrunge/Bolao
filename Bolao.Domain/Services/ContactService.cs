using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Base;
using Bolao.Domain.Arguments.Contact;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.ObjectValue;
using Bolao.Domain.ObjectValue.Validation;
using FluentValidation.Results;
using System;
using System.Reflection;

namespace Bolao.Domain.Services
{
    public sealed class ContactService : IContactService
	{
		private readonly IEmailService _emailService;

		public ContactService(IEmailService emailService)
		{
			_emailService = emailService;
		}

		public ContactResponse Contact(ContactRequest request)
		{
			ContactResponse response = new ContactResponse();

            try
            {
                // E-mail validation
                Email email = new Email(request.Email);
                EmailValidator emailValidator = new EmailValidator();
                ValidationResult emailResult = emailValidator.Validate(email);
                if (!emailResult.IsValid)
                    response.AddErrorValidationResult(emailResult);

                if (string.IsNullOrEmpty(request.Name))
                    response.AddError(new ErrorResponse("Name", string.Format(Msg.RequiredFieldX, "Nome")));

                if (string.IsNullOrEmpty(request.Subject))
                    response.AddError(new ErrorResponse("Subject", string.Format(Msg.RequiredFieldX, "Assunto")));

                if (string.IsNullOrEmpty(request.Message))
                    response.AddError(new ErrorResponse("Message", string.Format(Msg.RequiredFieldX, "Mensagem")));

                if (!response.IsValid())
                    return response;

                // Sending Email
                _emailService.SendEmailContact(request.Name, request.Email.Trim().ToLower(), request.Subject, request.Message);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }
	}
}
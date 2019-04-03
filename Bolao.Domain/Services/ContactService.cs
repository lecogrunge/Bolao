using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.ObjectValue;
using Bolao.Domain.ObjectValue.Validation;
using FluentValidation.Results;

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

			// E-mail validation
			Email email = new Email(request.Email);
			EmailValidator emailValidator = new EmailValidator();
			ValidationResult emailResult = emailValidator.Validate(email);
			if (!emailResult.IsValid)
				response.AddErrorValidationResult(emailResult);

			if (!response.IsValid())
				return response;

			// Sending Email
			_emailService.SendEmailContact(request.Name, request.Email, request.Subject, request.Message);

			return response;
		}
	}
}
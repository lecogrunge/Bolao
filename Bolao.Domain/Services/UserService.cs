using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Base;
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Domains;
using Bolao.Domain.Domains.Validator;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.ObjectValue;
using Bolao.Domain.ObjectValue.Validation;
using FluentValidation.Results;
using System;

namespace Bolao.Domain.Services
{
	public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IEmailService emailService)
        {
            this._userRepository = userRepository;
            this._emailService = emailService;
        }

		public AuthUserResponse AuthUser(AuthUserRequest request)
		{
			AuthUserResponse response = new AuthUserResponse();

			// E-mail validation
			Email email = new Email(request.Email);
			EmailValidator emailValidator = new EmailValidator();
			ValidationResult emailResult = emailValidator.Validate(email);
			if (!emailResult.IsValid)
				response.AddErrorValidationResult(emailResult);

			if (!response.IsValid())
				return response;

			// Verificar usuário existe
			User user = _userRepository.AuthUser(email.EmailAddress, request.Password.Trim());
			response.IdUser = user.IdUser;

			return response;
		}

		public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            CreateUserResponse response = new CreateUserResponse();

            // E-mail validation
            Email email = new Email(request.Email);
			EmailValidator emailValidator = new EmailValidator();
            ValidationResult emailResult = emailValidator.Validate(email);
            if (!emailResult.IsValid)
                response.AddErrorValidationResult(emailResult);

            // User validation
            User user = new User(request.FisrtName, request.LastName, email, request.Password);
			UserValidator userValidator = new UserValidator();
            ValidationResult userResult = userValidator.Validate(user);
            if (!userResult.IsValid)
                response.AddErrorValidationResult(userResult);

            if(!response.IsValid())
                return response;

            // Persistence
            _userRepository.Create(user);
						
			#region Sending Email
			string urlToken = "https://www.bolao.com.br?token=" + user.TokenUserCreated;
			string emailContent = string.Format(@"
								Olá {0}, estamos quase lá!<br />
								Por favor click no link abaixo para confirmar seu cadastro. <br />
								<a href='{1}' target='_blank'>Confirmar cadastro</a><br /><br />

								Caso você não tenha realizado nenhum cadastro em nosso sistema, favor desconsiderar esta mensagem.", user.FisrtName, urlToken);

			_emailService.SendEmail(user.Email.EmailAddress, "Confirmação de cadastro", emailContent);
			#endregion

			response.IdUser = user.IdUser;
            return response;
        }

		public ConfirmUserCreatedResponse ConfirmUserCreated(Guid token)
		{
			ConfirmUserCreatedResponse response = new ConfirmUserCreatedResponse();

			User user = _userRepository.GetUserByToken(token);
			if (user != null)
			{
				user.ActiveUser();
				_userRepository.Update(user);
			}
			else
				response.AddError(new ErrorResponseBase { Message = Msg.InvalidConfirmToken, Property = string.Empty });

			return response;
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

			return response;
		}
    }
}
using Bolao.CrossCutting.Common;
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
		private readonly IUserSecurityRepository _userSecurityRepository;
		private readonly IEmailService _emailService;
		
        public UserService(IUserRepository userRepository, IUserSecurityRepository userSecurityRepository, IEmailService emailService)
        {
            this._userRepository = userRepository;
			this._userSecurityRepository = userSecurityRepository;
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

			// Verificar usuário existe
			User user = _userRepository.AuthUser(email.EmailAddress, request.Password.CryptPassword());
            if (user == null)
                response.AddError(new ErrorResponseBase { Message = Msg.InvalidAuth, Property = null});

            if (!response.IsValid())
                return response;

            response.IdUser = user.UserId;
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
            
            if (_userRepository.IsEmailExist(user.Email.EmailAddress))
                response.AddError(new ErrorResponseBase {Message = Msg.EmailExists, Property = "Email" });

            if(!response.IsValid())
                return response;

            // Persistence 
            user.CryptPassword(user.Password);
            _userRepository.Create(user);

			// Send mail
			_emailService.SendEmailNewUser(user.Email.EmailAddress, user.UserSecurity.TokenCreateConfirmed, user.FisrtName);

			response.IdUser = user.UserId;
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

		public ForgotPasswordResponse ForgotPassword(string emailUser)
		{
			ForgotPasswordResponse response = new ForgotPasswordResponse();
			
			// E-mail validation
			Email email = new Email(emailUser);
			EmailValidator emailValidator = new EmailValidator();
			ValidationResult emailResult = emailValidator.Validate(email);
			if (!emailResult.IsValid)
				response.AddErrorValidationResult(emailResult);

			if (!response.IsValid())
				return response;


			// Persistence
			UserSecurity security = _userSecurityRepository.GetByEmail(email.EmailAddress);
			security.GenerateTokenForgotPassword();
			_userSecurityRepository.Update(security);

			// Send mail
			_emailService.SendEmailForgotPassword(email.EmailAddress);

			return response;
		}

		public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
		{
			throw new NotImplementedException();
		}
	}
}